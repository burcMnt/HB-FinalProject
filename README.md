# HepsiBurada Backend Bootcamp Final Project

Tamamlamis oldugum bitirme projemde temel CRUD islemleri ile kayit yapilabilen user adi verdigimiz müsteri hesaplari, bu müsteri hesaplarina bagli listeler
ve bu listelerin icinde satisi gerçeklesen ürünler vardir. Ayrica olusturulan listelere ürün eklenebilir, silinebilir ve çoklu ürün eklenebilir,silinebilir.
Projede Clean Architecture kullanilmis ve Solid prepsiplerine uygun yazilmaya çalisilmistir.
PostgreSql veri tabani kullanilarak EntityFramework ile islemler tanimlanmistir.
Ayrica listelere eklenen ürünler ayni zamanda çalisan bir Background-job yardimi ile MongoDb veri tabani üzerine de eklenmistir.
Isterlere göre olusturulan raporlar MongoDb den çekilip ayri bir Razor sayfasinda listelenmek üzere Distributed Cache yardimi ile Redis üzerinde tutulmustur.
Son olarak da Docker uygulamasý üzerinden

1- .NET Core Application

2- PostgreSql

3- MongoDB 
olmak üzere 3 container kaldirilmistir.

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
