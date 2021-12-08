/*==============================================================*/
/* DBMS name:      Microsoft Access 2000                        */
/* Created on:     19.02.2008 20:33:47                          */
/*==============================================================*/


alter table Pasutijumi
   drop constraint "FK_PASUTIJU_VEIC PASU_DARBINIE";

alter table Preces
   drop constraint FK_PRECES_IETILPST_KATEGORI;

alter table piegada
   drop constraint FK_PIEGADA_PIEGADA_PRECES;

alter table piegada
   drop constraint FK_PIEGADA_PIEGADA2_PIEGADAT;

alter table satur
   drop constraint FK_SATUR_SATUR_PASUTIJU;

alter table satur
   drop constraint FK_SATUR_SATUR2_PRECES;

drop table Darbinieki;

drop table Kategorijas;

drop table Pasutijumi;

drop table Piegadataji;

drop table Preces;

drop table piegada;

drop table satur;

/*==============================================================*/
/* Table: Darbinieki                                            */
/*==============================================================*/
create table Darbinieki
(
    DarbID               NUMERIC         not null,
    LietotVards          TEXT(25)        not null,
    Parole               TEXT(25)        not null,
    Nodala               TEXT(50)        not null,
    Menedzeris           YESNO           not null,
    Vards                TEXT(25)        not null,
    Uzvards              TEXT(25)        not null,
constraint PK_DARBINIEKI primary key (DarbID)
);

/*==============================================================*/
/* Table: Kategorijas                                           */
/*==============================================================*/
create table Kategorijas
(
    KatID                NUMERIC         not null,
    Nosaukums            TEXT(25)        not null,
    Apraksts             TEXT(50),
constraint PK_KATEGORIJAS primary key (KatID)
);

/*==============================================================*/
/* Table: Pasutijumi                                            */
/*==============================================================*/
create table Pasutijumi
(
    PasutID              NUMERIC         not null,
    DarbID               NUMERIC         not null,
    PasutDatums          DATE            not null,
    Status               YESNO           not null,
constraint PK_PASUTIJUMI primary key (PasutID)
);

/*==============================================================*/
/* Table: Piegadataji                                           */
/*==============================================================*/
create table Piegadataji
(
    PiegID               NUMERIC         not null,
    Nosaukums            TEXT(25)        not null,
constraint PK_PIEGADATAJI primary key (PiegID)
);

/*==============================================================*/
/* Table: Preces                                                */
/*==============================================================*/
create table Preces
(
    PrecesID             NUMERIC         not null,
    KatID                NUMERIC         not null,
    Nosaukums            TEXT(25)        not null,
    Apraksts             TEXT(50),
    CenaParVien          FLOAT           not null,
constraint PK_PRECES primary key (PrecesID)
);

/*==============================================================*/
/* Table: piegada                                               */
/*==============================================================*/
create table piegada
(
    PrecesID             NUMERIC         not null,
    PiegID               NUMERIC         not null,
constraint PK_PIEGADA primary key (PrecesID, PiegID)
);

/*==============================================================*/
/* Table: satur                                                 */
/*==============================================================*/
create table satur
(
    PasutID              NUMERIC         not null,
    PrecesID             NUMERIC         not null,
    Daudzums             INTEGER         not null,
    PiegDatums           DATE            not null,
constraint PK_SATUR primary key (PasutID, PrecesID)
);

alter table Pasutijumi
   add constraint "FK_PASUTIJU_VEIC PASU_DARBINIE" foreign key (DarbID)
      references Darbinieki (DarbID);

alter table Preces
   add constraint FK_PRECES_IETILPST_KATEGORI foreign key (KatID)
      references Kategorijas (KatID);

alter table piegada
   add constraint FK_PIEGADA_PIEGADA_PRECES foreign key (PrecesID)
      references Preces (PrecesID);

alter table piegada
   add constraint FK_PIEGADA_PIEGADA2_PIEGADAT foreign key (PiegID)
      references Piegadataji (PiegID);

alter table satur
   add constraint FK_SATUR_SATUR_PASUTIJU foreign key (PasutID)
      references Pasutijumi (PasutID);

alter table satur
   add constraint FK_SATUR_SATUR2_PRECES foreign key (PrecesID)
      references Preces (PrecesID);

