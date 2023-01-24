// Discriminating Union, e.g. custom types:
type Shape = 
    | Rectangle of width : float * length : float 
    | Circle of radius : float

let rect : Shape = Rectangle(1.5, 3.5);;
let circ : Shape = Circle(2.5);;

// Define simple area function using function for pattern matching
let pi = 3.141592;;
let area_func = function 
    | Rectangle (w, l)    -> printfn "%f" (w * l)
    | Circle r            -> printfn "%f" (r * r * pi);;

area_func rect;;
area_func circ;;

// Define simple area function using match ... with
let area_match s = 
    match s with
    | Rectangle (w, l)  -> printfn "%f" (w * l)
    | Circle r          -> printfn "%f" (r * r * pi);;

area_match rect;;
area_match circ;;

// Discriminating unions for trees
type Tree =
    | Null 
    | Node of int * Tree * Tree

// Sum values of tree recursively
let rec sumOfTree tree =
    match tree with
    | Null          -> 0
    | Node(v, l, r) -> v + sumOfTree(l) + sumOfTree(r);;

let myTree = Node(4, Node(3, Null, Node(1, Null, Null)), Node(3, Node(1, Null, Null), Node(2, Node(1, Null, Null), Null)));;

sumOfTree myTree;;

// Expression tree with type
type Expression = 
    | Number of int 
    | Add of Expression * Expression
    | Sub of Expression * Expression
    | Multiply of Expression * Expression
    | Variable of string

let rec eval (vars : Map<string, int>) exp = 
    match exp with
    | Number n              -> n 
    | Add (e1, e2)          -> eval vars e1 + eval vars e2
    | Sub (e1, e2)          -> eval vars e1 - eval vars e2
    | Multiply (e1, e2)     -> eval vars e1 * eval vars e2
    | Variable id           -> vars[id];;

let variables = Map ["a", 3; "b", 2];;

let myExp = Add(Sub(Number 7, Multiply(Number 2, Number 2)), Multiply(Variable "a", Variable "b"));;

eval variables myExp;;