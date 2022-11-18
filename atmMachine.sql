create table CreditCard
(
  CardId uniqueidentifier primary key,
  CardNumber BINARY(64) unique not null,
  Pin BINARY(64)  unique not null,
  Balance float ,
  
  ExpirationDate date  not null,
  NameOfOwner varchar(100) not null
  
  );

  create table Withdraw(

  Id uniqueidentifier primary key,
  DateofWithdraw date not null ,
  CardId uniqueidentifier not null foreign key references CreditCard(CardId),
  WithdrawValue float




  );

  create table  Deposit(

  DepositId uniqueidentifier primary key,

  DateOfDeposit date not null,
  cardNumber BINARY(64) not null,

CardId uniqueidentifier not null foreign key references CreditCard(CardId),
DepositValue float

  );





