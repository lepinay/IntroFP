let checksign p =
    if p < 0 then "p is negative"
    elif p = 0 then "p is nul"
    else "p is positive"

checksign 10