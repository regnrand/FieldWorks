rem WILL ONLY WORK IF WE'RE ON THE RIGHT DRIVE
REM HOW TO FIX THAT????
cd %FWROOT%\Bld
nant buildtest %1
