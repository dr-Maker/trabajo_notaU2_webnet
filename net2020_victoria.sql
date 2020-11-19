
-- create database net2020_victoria;

use net2020_victoria;

drop table pago;
drop table reserva;
drop table habitacion;
drop table cliente;

create table cliente(
idcliente int identity(1001,1),
nombres varchar(100) not null,
apellidos varchar(100) not null,
email varchar(100) not null,
telefono int not null,
primary key(idcliente)
);

create table habitacion(
idhabitacion int identity(2002,1),
numhab int not null,
detalle varchar(255) not null,
valordia int not null,
primary key(idhabitacion)
);

create table reserva(
idreserva int identity(3003,1),
idhabitacion int not null,
idcliente int not null,
fecha date not null,
numdias int not null,
fechaout date not null, 
total int default 0 not null,
estado int default 0 not null,
primary key(idreserva),
unique(fecha, idhabitacion),
foreign key(idhabitacion) references habitacion(idhabitacion),
foreign key(idcliente) references cliente(idcliente)
);

create table pago(
idpago int identity(5005,1),
idreserva int not null,
montopago int default 0 not null,
estado int default 0 not null,
primary key(idpago),
foreign key(idreserva) references reserva(idreserva)
);


insert into cliente values('Diego', 'Lorca', 'dglorca@victoria.cl', '987321654');
insert into cliente values('Ximena', 'Parra', 'xiparra@victoria.cl', '965432178');
insert into cliente values('Sophia', 'Lillo', 'splillo@victoria.cl', '925863147');
insert into cliente values('Elena', 'Navarro', 'elnavarro@victoria.cl', '974156328');
insert into cliente values('Ricardo', 'Castillo', 'ricastillo@victoria.cl', '982453217');
insert into cliente values('Rodrigo', 'Ponce', 'rponceb@victoria.cl', '917658345');
insert into cliente values('Jazmin', 'Pardo', 'jzpardo@victoria.cl', '967183452');

insert into habitacion values('305', 'Habitacion confortable, 1 cama, 1 baño', '35990');
insert into habitacion values('306', 'Habitacion confortable, 1 cama, 1 baño', '35990');
insert into habitacion values('307', 'Habitacion confortable, 1 cama, 1 baño', '35990');
insert into habitacion values('401', 'Habitacion confortable, 2 camas, 1 baño', '49990');
insert into habitacion values('402', 'Habitacion confortable, 2 camas, 1 baño', '49990');
insert into habitacion values('403', 'Habitacion confortable, 1 cama 2 plazas, 1 baño', '55990');
insert into habitacion values('404', 'Habitacion confortable, 1 cama 2 plazas, 1 baño', '55990');

insert into reserva values(2002, 1001, getdate(), 3, getdate()+3, 0, 0);
insert into reserva values(2005, 1002, getdate(), 5, getdate()+5, 0, 0);
insert into reserva values(2008, 1006, getdate(), 7, getdate()+7, 0, 0);

update reserva set total = numdias*h.valordia
from reserva r
join habitacion h on r.idhabitacion = h.idhabitacion;


select 
r.*,
h.numhab, h.detalle, h.valordia,
c.nombres, c.apellidos, c.email, c.telefono
from reserva r 
join habitacion  h    on r.idhabitacion  =  h.idhabitacion
join cliente     c    on r.idcliente     =  c.idcliente

