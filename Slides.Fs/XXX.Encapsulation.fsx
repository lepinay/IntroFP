let evens list =
   let isEven x = x%2 = 0     
   List.filter isEven list    

evens [2;3;4;5]                