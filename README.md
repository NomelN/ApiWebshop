# Documentation ApiWebshop

![mspr](https://user-images.githubusercontent.com/61651276/225070332-ea05cf7a-2f32-4899-a0d0-032502728375.PNG)

L'API Webshop permet d'accéder, à la liste des produits disponibles dans notre ERP et de voir les détails de chaque produits, à la liste des clients, d'obtenir des informations sur un client spécifique, de récupérer les commandes passées par un client et de récupérer les produits d'une commande.

# Endpoints
L'API Webshop expose les endpoints suivants :

GET /api/webshop/produits :Récupère la liste de tous les produits

GET /api/webshop/produits{idProduits} :Récupère les détails d'un produit spécifique

GET /api/webshop/clients	:Récupère la liste de tous les clients

GET /api/webshop/clients/{idClient}	:Récupère les informations d'un client spécifique

GET /api/webshop/clients/{idClient}/:commandes	Récupère les commandes passées par un client

GET /api/webshop/clients/{idClient}/:commandes/{idCommande}/produits	Récupère les produits d'une commande

# Authentification
Les utilisateurs qui peuvent avoir accès aux données sont spécifiés dans le code.

L'authentification est requise pour accéder à certains points de terminaison de l'API. L'API utilise l'authentification JWT, qui implique l'envoi d'un jeton dans l'en-tête Authorization de la requête HTTP.

  # Connexion
Pour obtenir un jeton JWT, l'utilisateur doit envoyer une requête 

POST /api/webshop/authentication/login 

avec un objet JSON contenant son email et son mot de passe.

Si l'e-mail et le mot de passe sont corrects, l'API répondra avec un jeton JWT. Le jeton peut ensuite être envoyé dans l'en-tête Authorization des requêtes ultérieures pour authentifier l'utilisateur.

Exemple de demande :

http

POST /api/webshop/authentication/login HTTP/1.1

Type de contenu : application/json

{

   "email": "utilisateur@exemple.com",
      
   "mot de passe": "mot de passe"
   
}

  # Accéder aux endpoints protégés
Pour accéder à un point de terminaison protégé, l'utilisateur doit envoyer une demande avec un jeton JWT dans l'en-tête d'autorisation. Le jeton doit être préfixé par la chaîne "Bearer", comme ceci :

http

GET /api/boutique en ligne/produits HTTP/1.1
Autorisation : Bearer token
Si le jeton est valide, l'API répondra avec les données demandées. Si le jeton n'est pas valide ou a expiré, l'API répondra avec un code HTTP 400 (Bad Request) non autorisé.

