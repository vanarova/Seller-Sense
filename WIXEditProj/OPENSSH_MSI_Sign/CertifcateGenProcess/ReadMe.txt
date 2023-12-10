Process for singing:
- Copy SS.msi to OPENSSH_MSI_Sign directory
- run sign.bat file, should sign mdi file.
- done


Process for generating cert and signing using open ssl
1. Download openssl compact version, link given in article.
2. follow commands to generate key pair, certificate and p12 file.
3. Ksign mentioned in article is not working properly, downloaded signtool.exe from microsoft, it comes in win SDK10 package. Installed only win cert module.
4. Follow another article given in this dir to use sign tool, Created a .bat file for future signing.