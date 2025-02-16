# Online_store_website
Online store website project. The frontend part is written in Angular, backend in ASP.Net.
Database on MSSQL, data caching using Redis. 

The project consists of three parts:
 - 'backend': (ASP.NET) Main logic of the application with REST API.
 - 'frontend' (Angular 18) Main page of the application.
 - 'microservice' (ASP.Net) A microservice that provides logic for user authorization.

Instructions for launching the project:
 - Download the project to any directory on your computer.
 - Open the CMD console and go to the directory where the project was downloaded.
 - Deploy Docker containers with command ..\Online_store_website>docker compose up
 - Open any browser and open the project web page http://localhost:4200/

The project is still in development.
