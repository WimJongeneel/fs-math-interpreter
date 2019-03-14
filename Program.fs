// Learn more about F# at http://fsharp.org
namespace Querylang
module Main = 
  open Microsoft.FSharp.Text.Lexing
  open Expression
  open System.IO

  let dumpRes s =
    printfn "\n %s" s
    try
      let lexbuf = LexBuffer<char>.FromString s
      let expr: Expr = Parser.start Lexer.tokenstream lexbuf
      printf "\n"
      printf "%A\n" expr
      printf "%i\n" <| evalExpr expr
    with
      | ex -> printf "%s" ex.Message

  [<EntryPoint>]
  let main argv =


    dumpRes "100 + 5 * 10"
    dumpRes "(100 + 5) * 10"

    0