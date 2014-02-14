namespace JSLibraryFunctional.Search.AStar
    module Frontier =
        
        type Frontier<'a> when 'a : comparison = (Map<'a,int * 'a>*Set<int * 'a>)

        let Add = 1
        
