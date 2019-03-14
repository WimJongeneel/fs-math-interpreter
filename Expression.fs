module Expression

  type Expr =
    | Int         of int32
    | Parentheses of Expr
    | Plus        of Expr * Expr
    | Times       of Expr * Expr
    | Divide      of Expr * Expr
    | Minus       of Expr * Expr

  let rec compileExpr (e: Expr) = 
    match e with
      | Parentheses e     -> compileExpr e |> sprintf "(%s)"
      | Plus (l, r)       -> (compileExpr l, compileExpr r) ||> sprintf "(%s + %s)"
      | Times (l, r)      -> (compileExpr l, compileExpr r) ||> sprintf "(%s * %s)"
      | Divide (l, r)     -> (compileExpr l, compileExpr r) ||> sprintf "(%s / %s)"
      | Minus (l, r)      -> (compileExpr l, compileExpr r) ||> sprintf "(%s - %s)"
      | Int i             -> string i

  let rec evalExpr (e: Expr) = 
    match e with
      | Parentheses e     -> evalExpr e
      | Plus (l, r)       -> evalExpr l + evalExpr r
      | Minus (l, r)      -> evalExpr l - evalExpr r
      | Divide (l, r)     -> evalExpr l / evalExpr r
      | Times (l, r)      -> evalExpr l * evalExpr r
      | Int i             -> i