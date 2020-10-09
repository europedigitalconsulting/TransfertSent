# TransfertSent

1 - Copier les dossiers dans le projet
2 - Créer le dossier "TransferSent" dans Front->Features
3 - Ajouter le projet Cryptocoin.Client.Features.TransferSent.csproj dans le dossier "TransferSent"
4 - Dans le projet Cryptocoin.client ajouter la référence de projet Cryptocoin.Client.Features.TransferSent
5 - Installer la package Microsoft.AspNetCore.Mvc.ViewFeatures dans le projet Cryptocoin.Client
6 - Ajouter "@using Microsoft.AspNetCore.Mvc.Rendering" dans le fichier "_import.razor" du projet Cryptocoin.Client

Dans NavMenu.razor

<li class="nav-item">
	<a class="nav-link" href="/transfersent" title="transfersent"><i style="color: #fff;" class="fa fa-user-circle"><span class="sr-only">>TransferSent</span></i></a>
</li>