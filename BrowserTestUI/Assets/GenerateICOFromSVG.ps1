Write-Host "Be sure Image Magick is installed and in your path before running this script!"
magick convert btui-logo.svg -resize 16x16 16.png
magick convert btui-logo.svg -resize 32x32 32.png
magick convert btui-logo.svg -resize 48x48 48.png
magick convert btui-logo.svg -resize 64x64 64.png

Write-Host "PNG files generated. Creating ICO."
magick convert 16.png 32.png 48.png 64.png btui-logo.ico

Write-Host "Cleaning up temporary PNG files."
Remove-Item 16.png
Remove-Item 32.png
Remove-Item 48.png
Remove-Item 64.png