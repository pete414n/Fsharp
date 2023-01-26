type point = 
    { X : int;
      Y : int;
      Z : int;
    }

let p = {X = 1; Y = 2; Z = 3;};;

// Copy and update record expression
let p2 = {p with Y = 5};;

// Mutually recursive records
type Person = 
    {
        Name : string;
        Age : int;
        Address : Address;
    }
and Address = 
    { 
        Street : string;
        Number : int;
        PostCode : string;
    }

let test_person = {Name = "Paul"; Age = 43; Address =
    {
        Street = "Vejnavn"; Number = 12; PostCode = "2323";
    }}