type Player = 
    { x : int
      y : int
      lives : int
      score : int }

type Level = 
    { remainingTime : int }

type Game = 
    { player : Player
      level : Level }
    member x.apply (f, c) = 
        let (s',_) = (f x)
        c s'
    member x.ret f =
       let (s',_) = (f x)
       s' 
    

let game = 
    { player = 
          { x = 0
            y = 0
            lives = 2
            score = 0 }
      level = { remainingTime = 90 } }

let movePlayerLeft game = { game with player = { game.player with x = game.player.x - 1 } }, ()
let movePlayerRight game = { game with player = { game.player with x = game.player.x + 1 } }, ()
let updateGameTime game = { game with level = { game.level with remainingTime = game.level.remainingTime - 1 } }, ()
let getGameScore game = game, game.player.score
let setGameScore score game = { game with player = { game.player with score = score } }, ()

// 1. The problem: State travel
let (game', ()) = movePlayerLeft game
let (game'', ()) = movePlayerLeft game'
let (game''', ()) = updateGameTime game''
let (game'''', score) = getGameScore game'''
let (game''''', ()) = setGameScore (score + 1) game''''

// 2. A solution without temporary variables
let value = 
    fun (state, _) -> 
        movePlayerLeft state 
            |> fun (state, _) -> 
                movePlayerLeft state 
                |> fun (state, _) -> 
                    updateGameTime state

// 3. Event shorterLet's hide the state into an helper function
let value =
    game.apply(movePlayerLeft, fun game -> 
        game.apply(movePlayerLeft, fun game -> 
            game.ret(updateGameTime) ) )

apply(movePlayerLeft, fun game ->
   apply(movePlayerLeft, fun game ->
        updateGameTime        
   ) 
)

// 4. rewritten for readability
let value =
    game.apply(movePlayerLeft, fun game -> 
    game.apply(movePlayerLeft, fun game -> 
    game.ret(updateGameTime) ) )

type State<'S,'A> = | State of 'S*('S -> ('S*'A))

let createGame = State(game,fun g ->(g,()))

type StateBuilder() =
    member this.Bind(x,f) =
        match x with 
            | State(curr,effect) ->
                let (state',res) = effect curr
                f state'

    member this.Return(x) = State(x, fun g -> g )

let state = new StateBuilder()
state {
    do! createGame
    do! movePlayerLeft
}

let value = 
    game.bind(fun state ->
       (movePlayerLeft state ).bind(fun state ->
           movePlayerLeft state 
       )
    )

type Effect = Game -> Game

let bind (e:Effect) (f:Game->Effect) =
    let s' =  
    

bind game movePlayerLeft state 


// 2. Same solution but more readable
let value = 
    fun (state, _) -> 
        movePlayerLeft state |> fun (state, _) -> 
        movePlayerLeft state |> fun (state, _) -> 
        updateGameTime state



value (game, ())
State.bind (fun (state, _) -> (movePlayerLeft state).bind(fun (state', _) -> movePlayerRight game'))
