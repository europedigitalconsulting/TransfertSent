# Transfert

Pages Front et Appel API inclus dans ce Repo

1. Copier les dossiers dans le projet
2. Créer un nouveau dossier de solution  "TransferSent" et "TransferReceived" dans Front->Features
3. Ajouter le projet Cryptocoin.Client.Features.TransferSent.csproj dans le dossier "TransferSent"
3. Ajouter le projet Cryptocoin.Client.Features.TransferReceived.TypeFriend.csproj dans le dossier "TransferSent"
3. Ajouter le projet Cryptocoin.Client.Features.TransferReceived.TypeUser.csproj dans le dossier "TransferSent"
3. Ajouter le projet Cryptocoin.Client.Features.TransferReceived.TypePhysical.csproj dans le dossier "TransferSent"
3. Ajouter le projet Cryptocoin.Client.Features.TransferReceived.csproj dans le dossier "TransferReceived"
4. Dans le projet Cryptocoin.client ajouter la référence de projet Cryptocoin.Client.Features.TransferSent
4. Dans le projet Cryptocoin.client ajouter la référence de projet Cryptocoin.Client.Features.TransferSent.TypeFriend
4. Dans le projet Cryptocoin.client ajouter la référence de projet Cryptocoin.Client.Features.TransferSent.TypeUser
4. Dans le projet Cryptocoin.client ajouter la référence de projet Cryptocoin.Client.Features.TransferSent.TypePhysical 
4. Dans le projet Cryptocoin.client ajouter la référence de projet Cryptocoin.Client.Features.TransferReceived
5. Installer la package Microsoft.AspNetCore.Mvc.ViewFeatures dans le projet Cryptocoin.Client
6. Ajouter "@using Microsoft.AspNetCore.Mvc.Rendering" et "@using Cryptocoin.Client.Features.Transfer.Sent"dans le fichier "_import.razor" du projet Cryptocoin.Client

