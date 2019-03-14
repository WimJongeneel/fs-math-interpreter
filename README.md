# fs-math-interpreter

Made in F# with FsLexYacc.

```
dotnet run "1 + 1 * 2"
```

This will print the AST and the result of the expression

Supported operators:
* atomic int: `1`
* plus: `+`
* minus: `-`
* times: `*`
* division: `/`
* parentheses: `(` and `)`

Operator precedence is implemented in the grammer by using multiple rules.