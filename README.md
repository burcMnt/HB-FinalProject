# HepsiBurada Backend Bootcamp Final Project

Tamamlamis oldugum bitirme projemde temel CRUD islemleri ile kayit yapilabilen user adi verdigimiz m�steri hesaplari, bu m�steri hesaplarina bagli listeler
ve bu listelerin icinde satisi ger�eklesen �r�nler vardir. Ayrica olusturulan listelere �r�n eklenebilir, silinebilir ve �oklu �r�n eklenebilir,silinebilir.
Projede Clean Architecture kullanilmis ve Solid prepsiplerine uygun yazilmaya �alisilmistir.
PostgreSql veri tabani kullanilarak EntityFramework ile islemler tanimlanmistir.
Ayrica listelere eklenen �r�nler ayni zamanda �alisan bir Background-job yardimi ile MongoDb veri tabani �zerine de eklenmistir.
Isterlere g�re olusturulan raporlar MongoDb den �ekilip ayri bir Razor sayfasinda listelenmek �zere Distributed Cache yardimi ile Redis �zerinde tutulmustur.
Son olarak da Docker uygulamas� �zerinden

1- .NET Core Application

2- PostgreSql

3- MongoDB 
olmak �zere 3 container kaldirilmistir.

## Entities

><img src="https://github.com/Hepsiburada-Backend-Bootcamp/BurcuMantar-Hepsiburada-FinalProject/blob/master/src/Core/App.ApplicationCore/Images/ItemEntity.png"/>

><img src="https://github.com/Hepsiburada-Backend-Bootcamp/BurcuMantar-Hepsiburada-FinalProject/blob/master/src/Core/App.ApplicationCore/Images/userListEntity.png"/>

><img src="https://github.com/Hepsiburada-Backend-Bootcamp/BurcuMantar-Hepsiburada-FinalProject/blob/master/src/Core/App.ApplicationCore/Images/OrderEntity.png"/>


## Swagger

#### ItemController

><img src="https://github.com/Hepsiburada-Backend-Bootcamp/BurcuMantar-Hepsiburada-FinalProject/blob/master/src/Core/App.ApplicationCore/Images/itemCrud.png"/>

><img src="https://github.com/Hepsiburada-Backend-Bootcamp/BurcuMantar-Hepsiburada-FinalProject/blob/master/src/Core/App.ApplicationCore/Images/item1.png"/>

#### ListOfUser Controller

><img src="https://github.com/Hepsiburada-Backend-Bootcamp/BurcuMantar-Hepsiburada-FinalProject/blob/master/src/Core/App.ApplicationCore/Images/ListOfUserCrud.png"/>

><img src="https://github.com/Hepsiburada-Backend-Bootcamp/BurcuMantar-Hepsiburada-FinalProject/blob/master/src/Core/App.ApplicationCore/Images/listofuser1.png"/>

#### User Controller

><img src="https://github.com/Hepsiburada-Backend-Bootcamp/BurcuMantar-Hepsiburada-FinalProject/blob/master/src/Core/App.ApplicationCore/Images/UserCrud.png"/>

><img src="https://github.com/Hepsiburada-Backend-Bootcamp/BurcuMantar-Hepsiburada-FinalProject/blob/master/src/Core/App.ApplicationCore/Images/user1.png"/>


## PostgreSql

><img src="https://github.com/Hepsiburada-Backend-Bootcamp/BurcuMantar-Hepsiburada-FinalProject/blob/master/src/Core/App.ApplicationCore/Images/postgre.png"/>

## MongoDb

><img src="https://github.com/Hepsiburada-Backend-Bootcamp/BurcuMantar-Hepsiburada-FinalProject/blob/master/src/Core/App.ApplicationCore/Images/Mongodb.png"/>

## Hangfire&Cache

><img src="https://github.com/Hepsiburada-Backend-Bootcamp/BurcuMantar-Hepsiburada-FinalProject/blob/master/src/Core/App.ApplicationCore/Images/hangfire%26cache.png"/>
><img src=""/>
><img src=""/>

## Docker 

><img src="https://github.com/Hepsiburada-Backend-Bootcamp/BurcuMantar-Hepsiburada-FinalProject/blob/master/src/Core/App.ApplicationCore/Images/Docker.png"/>

## DBeaver

><img src="https://github.com/Hepsiburada-Backend-Bootcamp/BurcuMantar-Hepsiburada-FinalProject/blob/master/src/Core/App.ApplicationCore/Images/DBeaver.png"/>
