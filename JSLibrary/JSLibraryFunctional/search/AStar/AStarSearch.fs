namespace JSLibraryFunctional.Search.AStar
    module AStarSearch = 

        open Frontier

        type Node<'a> =
            { 
                data    : 'a;
                parent  : Node<'a>;
                cost    : int;
            }



        let as_find_goal<'a> (getAdj:('a -> 'a list)) (init:Node<'a>) (goal:'a) = 
            ()
        
        let as_sub_adj_func e o f t g = 
            
            let found = Map.tryFind t.data o
            //update open
            let a = Frontier.test
            let o' = match found with
                            | Some (n:Node<_>) ->  
                                if n.cost > t.cost then
                                    Set.add n.data o
                                    |> Map.add t.data t
                                else
                                    o
                            | None ->  o
            ()
            