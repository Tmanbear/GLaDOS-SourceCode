@ECHO OFF
echo Aperture Science Remote Shell Help

echo (c) 2017
echo --
echo "play - music subshell"
echo "cd [.|..|filepath] - changes working directory (it is possible to exit the fake 'G' drive and explore other file on the computer. However, the prompt will not change once you go back begind the C:\GLaDOS_SHELL folder)"
echo "ls - reads files in current directory"
echo "dir - reads files in current directory"
echo "stop - stops music"
echo "comment /specimen chell /name [name] - add comment to chell's comment file"
echo "reboot" - reboots the system
echo "exit" - exits the shell
echo "write - initilizes multilines text editor (use '`' or '~' to save and exit)"
 set /p read="Press return to exit..."
