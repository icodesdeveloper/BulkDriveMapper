
# BulkDriveMapper
A simple C# Command App that maps fast network shares in bulk.

## Instructions

 1. Run the program
 2. Enter the IP Address of the server you want to map to, for example: 192.168.178.102 
     Or: nas.local
     
 3. Enter the username on the server, this can be with an active directory
      For example: root or: CONTOSO\files
 
 4. Enter the password for the user
 5. Now enter the letter you want to map to, a : is not needed. 
 6. To finish the mounting process enter the share name you want to mount, you can use a \ to dive into subdirs.
 7. The drive has been mounted and you can start with the next one, if you want to change credentials or ip, type 'su' or type 'stop' to exit.

## Notes
This app has been written very fast so the code is quite messy, but it works and does what it should do.
