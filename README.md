# Documentation ApiWebshop

![mspr](https://user-images.githubusercontent.com/61651276/225070332-ea05cf7a-2f32-4899-a0d0-032502728375.PNG)

L'API Webshop permet d'accéder, à la liste des produits disponibles dans notre ERP et de voir les détails de chaque produits, à la liste des clients, d'obtenir des informations sur un client spécifique, de récupérer les commandes passées par un client et de récupérer les produits d'une commande.

Endpoints
L'API Webshop expose les endpoints suivants :
Endpoint	Description
GET /api/webshop/clients	:Récupère la liste de tous les clients
GET /api/webshop/clients/{idClient}	:Récupère les informations d'un client spécifique
GET /api/webshop/clients/{idClient}/:commandes	Récupère les commandes passées par un client
GET /api/webshop/clients/{idClient}/:commandes/{idCommande}/produits	Récupère les produits d'une commande
