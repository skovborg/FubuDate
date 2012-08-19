Why does `git status` show that all of my files are modified?
--
FubuDate is built by Windows users, so all of the text files have CRLF line endings. These line endings are stored as-is in git (which means we all have autocrlf turned off).
If you have autocrlf enabled, when you retrieve files from git, it will modify all of your files. Your best bet is to turn off autocrlf, and re-create your clone of FubuCore.

1. Delete your local clone of the FubuDate repository
1. Type: `git config --global core.autocrlf false`
1. Type: `git config --system core.autocrlf false`
1. Clone the FubuDate repository again