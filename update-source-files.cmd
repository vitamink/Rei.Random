mkdir .\temp
rmdir /S /Q .\temp\latest
.\tools\curl\curl.exe http://www.rei.to/Rei.Random1.0.0.zip > .\temp\Rei.Random1.0.0.zip
.\tools\7zip\7za.exe x .\temp\Rei.Random1.0.0.zip -o.\temp\latest
call .\tools\importer\Rei.Importer.exe "temp\latest\Rei.Random\Random" "src\Rei.Random"