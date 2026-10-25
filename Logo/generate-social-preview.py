#!/usr/bin/env python3
"""Generates the GitHub social preview card (1280x640) for UnitConversion.

    python3 Logo/generate-social-preview.py

Writes Logo/social-preview.svg and Logo/social-preview.png. Needs fontTools, ImageMagick (with the RSVG
delegate) and the Montserrat font. Text is converted to paths so the card looks the same everywhere.
Upload the PNG in the repository settings (General, Social preview); GitHub has no API for it.
"""
import re
import subprocess
import sys
from pathlib import Path

from fontTools.pens.svgPathPen import SVGPathPen
from fontTools.pens.transformPen import TransformPen
from fontTools.ttLib import TTFont

ROOT = Path(__file__).resolve().parent.parent
OUT = ROOT / "Logo"
FONT_DIR = Path("/usr/share/fonts/julietaula-montserrat-fonts")

NAVY, NAVY_DARK, NAVY_LIGHT = "#012456", "#011A3E", "#0A3C80"
SKY, AMBER, TEXT, MUTED = "#7DD3FC", "#FCD34D", "#F8FAFC", "#B6C6E0"
W, H = 1280, 640

_fonts = {}


def font(name):
    if name not in _fonts:
        f = TTFont(FONT_DIR / f"Montserrat-{name}.otf")
        _fonts[name] = (f, f.getGlyphSet(), f.getBestCmap(), f["head"].unitsPerEm)
    return _fonts[name]


def text_width(text, size, weight="Bold"):
    f, _, cmap, upm = font(weight)
    return sum(f["hmtx"][cmap[ord(c)]][0] for c in text) * size / upm


def text_path(text, x, y, size, fill, weight="Bold"):
    f, gs, cmap, upm = font(weight)
    scale, cursor, d = size / upm, 0.0, []
    for ch in text:
        g = cmap[ord(ch)]
        pen = SVGPathPen(gs)
        gs[g].draw(TransformPen(pen, (scale, 0, 0, -scale, x + cursor, y)))
        d.append(pen.getCommands())
        cursor += f["hmtx"][g][0] * scale
    return f'<path d="{" ".join(d)}" fill="{fill}"/>'


def logo_paths():
    """The existing UnitConversion mark, recoloured by the caller."""
    svg = (OUT / "UnitConversion.svg").read_text(encoding="utf-8")
    return "".join(re.findall(r"<path[^>]*/>", svg)).replace('class="cls-1"', "")


def code_line(parts, x, y, size=24):
    out, cursor = [], x
    for text, color in parts:
        out.append(text_path(text, cursor, y, size, color, "Medium"))
        cursor += text_width(text, size, "Medium")
    return "".join(out)


def pill(x, y, label, size=17):
    w = text_width(label, size, "SemiBold") + 32
    return (f'<rect x="{x}" y="{y}" width="{w:.1f}" height="38" rx="19" fill="none" stroke="{SKY}" '
            f'stroke-opacity="0.5" stroke-width="1.5"/>' + text_path(label, x + 16, y + 25, size, TEXT, "SemiBold"), w)


def build():
    pills, x, y = [], 470, 478
    for label in ["Mass", "Distance", "Temperature", "Volume", "Speed", "Energy", "Pressure", "Power",
                  "Area", "Time", "Angle", "Digital storage"]:
        p, w = pill(x, y, label)
        if x + w > W - 60:
            x, y = 470, y + 50
            p, w = pill(x, y, label)
        pills.append(p)
        x += w + 12
    code = [
        code_line([("new ", "#C4B5FD"), ("MassConverter", TEXT), ("(", MUTED), ('"kg"', "#5EEAD4"), (", ", MUTED),
                   ('"lbs"', "#5EEAD4"), (")", MUTED)], 494, 368),
        code_line([(".", MUTED), ("LeftToRight", AMBER), ("(452, 2);", MUTED), ("  // 996.49", "#7B8DAA")], 494, 406),
    ]
    return f"""<svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 {W} {H}" width="{W}" height="{H}" role="img" aria-label="UnitConversion: exact unit conversion for .NET">
  <defs>
    <linearGradient id="bg" x1="0" y1="0" x2="1" y2="1"><stop offset="0" stop-color="{NAVY_DARK}"/><stop offset="1" stop-color="{NAVY}"/></linearGradient>
    <radialGradient id="glow" cx="0.9" cy="0.1" r="0.6"><stop offset="0" stop-color="{NAVY_LIGHT}" stop-opacity="0.9"/><stop offset="1" stop-color="{NAVY_LIGHT}" stop-opacity="0"/></radialGradient>
    <pattern id="dots" width="24" height="24" patternUnits="userSpaceOnUse"><circle cx="2" cy="2" r="1.1" fill="#FFFFFF" fill-opacity="0.07"/></pattern>
  </defs>
  <rect width="{W}" height="{H}" fill="url(#bg)"/>
  <rect width="{W}" height="{H}" fill="url(#dots)"/>
  <rect width="{W}" height="{H}" fill="url(#glow)"/>
  <rect x="70" y="120" width="360" height="400" rx="40" fill="#FFFFFF"/>
  <g transform="translate(90 160) scale(0.4)" fill="{NAVY}">{logo_paths()}</g>
  {text_path("UnitConversion", 470, 190, 66, TEXT)}
  {text_path("Exact unit conversion for .NET.", 470, 248, 28, SKY, "SemiBold")}
  {text_path("Exact definitions, synonym-based unit names,", 470, 292, 22, MUTED, "Medium")}
  {text_path("no dependencies.", 470, 322, 22, MUTED, "Medium")}
  <rect x="470" y="342" width="640" height="82" rx="14" fill="#000000" fill-opacity="0.32"/>
  {"".join(code)}
  {"".join(pills)}
</svg>
"""


def main():
    svg = OUT / "social-preview.svg"
    svg.write_text(build(), encoding="utf-8")
    subprocess.run(["magick", "-background", "none", "-density", "192", str(svg), "-resize", f"{W}x", "-depth", "8", "-strip",
                    str(OUT / "social-preview.png")], check=True)
    print("wrote Logo/social-preview.svg and .png")


if __name__ == "__main__":
    sys.exit(main())
