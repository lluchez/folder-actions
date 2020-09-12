# Folder Actions
Developed with C#

## What is Folder Actions

Folder Actions is a Windows program to be batch-process multiple files at once. Current plugins allow you to:
- compress, resize or change the format of multiple images at once
- append text files
- batch rename multiple files

Folder Actions also support Shell integration to run it directly by right-clicking onto a directory.

For more information, please visit https://lluchez.com/#/programs/folder_actions

## Screenshots

List view:
![List view](/docs/folder_actions_list_view.png)

Thumbnail view:
![Thumbnail view](/docs/folder_actions_thumbs_view.png)

Image Compressor plugin view:
![Image Compressor plugin view](/docs/folder_actions_images_compressor.png)

Files Renamer plugin view:
![Files Renamer plugin view](/docs/folder_actions_files_renamer.png)

Files Appender plugin view:
![Files Appender plugin view](/docs/folder_actions_files_appender.png)

Shell integration:
![Shell integration](/docs/folder_actions_shell_integration.png)


## Confiuguration file:

Configuration file `Settings.ini` sample:

```ini
[General]
ViewHiddenFiles=False
Recursive=False

[Selector]
ViewAllFiles=False

[Selector.Types]
Image=jpeg;jpg;png;gif;bmp
Music=3gp;aac;amr;atrac;flac;m4a;m4p;mp3;ogg;wav;wma
Video=3gp;asf;avi;cam;flv;m1v;m2v;m4v;mkv;mov;mp4;mpeg;mpg;swf;wmv

[Plugin.Renamer]
Overwrite=False

[Plugin.ImgCompressor]
JpegCompression=90
ResizingRatio=1/2
InterpolationMode=High Quality Bicubic
EnableParallelProcessing=True
ParallelThreads=7
```
