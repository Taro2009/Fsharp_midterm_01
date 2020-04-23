namespace hw1try232143124213

open WebSharper
open WebSharper.JavaScript
open WebSharper.JQuery
open WebSharper.UI
open WebSharper.UI.Client
open WebSharper.UI.Templating

[<JavaScript>]
module Client =
    // The templates are loaded from the DOM, so you just can edit index.html
    // and refresh your browser, no need to recompile unless you add or remove holes.

    type IndexTemplate = Template<"wwwroot/index.html", ClientLoad.FromDocument>



    [<SPAEntryPoint>]
    let Main () =

        // Itt hozzuk létre a változókat amik a mûködéshez kellenek, num1 és num2 a két operandus, operator az operátor és a disp az amit kiírunk a képernyõre
        let mutable num1 = Var.Create ""
        let mutable num2 = Var.Create ""
        let mutable operator = Var.Create ""
        let mutable disp = Var.Create ""

        // Ez a függvény nézi, hogy mi az operátpr és az alapján pattern matchinggel végez egy megfelelõ mûveletet, majd az eredményt belepakolja a num2-be
        let Calc (op: Var<string>, n1: int, n2: Var<string>, n3: Var<string>) =

            match op.Value with
            | "+" -> n3.Value <- (float n1 + float n2.Value).ToString()
            | "-" -> n3.Value <- (float n2.Value - float n1).ToString()
            | "*" -> n3.Value <- (float n1 * float n2.Value).ToString()
            | "/" -> 
                if n1 = 0 then          // Itt csinálunk egy kis vizsgálatot a 0-val való osztásra
                    n3.Value <- "E"
                else
                    n3.Value <- (float n2.Value / float n1).ToString()
            | "1/" -> n2.Value <- (1. / float n2.Value).ToString()
            | "sin" -> n2.Value <- (Math.Sin(float n2.Value)).ToString()
            | "cos" -> n2.Value <- (Math.Cos(float n2.Value)).ToString()

        // Ezek a függvények amik a C-t és AC-t végzik
        let Clearnum1() =
            num1.Value <- ""
            
        let Clearnum2() =
            num2.Value <- ""

        let Clearop() =
            operator.Value <- ""
        
        let Cleardisp() =
            disp.Value <- ""


        IndexTemplate.Main()
            
            // Ez a felelõs az eredmény kiírásáért, összekapcsoljuk az index.html-es Result ws-var-ral
            .Result(
                disp
            )

            // Itt figyeljük egyenként a számos gombok megnyomását, if-fel külön nézzük, hogy volt-e megnyomva elõtte egy operátor vagy sem, és ez alapján viselkedik a program. Csak a 0-ásnál van
            // extra kód, ez a 0-val  való osztás akadályozása miatt kell, ha valaki 0-val akar osztani, kiírunk egy E-t és minden regisztert törlünk
            .zero(fun _ ->
                if operator.Value <> "" then
                    Calc (operator, 0, num1, num2)
                    if num2.Value = "E" then
                        Clearnum1()
                        Clearnum2()
                        Clearop()
                        Cleardisp()
                        disp.Value <- "E"
                    else
                        disp.Value <- "0"
                else
                    num1.Value <- "0"
                    disp.Value <- "0"
            )
            .one(fun _ ->
                if operator.Value <> "" then
                    Calc (operator, 1, num1, num2)
                    disp.Value <- "1"
                else
                    num1.Value <- "1"
                    disp.Value <- "1"
            )
            .two(fun _ ->
                if operator.Value <> "" then
                    Calc (operator, 2, num1, num2)
                    disp.Value <- "2"
                else
                    num1.Value <- "2"
                    disp.Value <- "2"
            )
            .three(fun _ ->
                if operator.Value <> "" then
                    Calc (operator, 3, num1, num2)
                    disp.Value <- "3"
                else
                    num1.Value <- "3"
                    disp.Value <- "3"
            )
            .four(fun _ ->
                if operator.Value <> "" then
                    Calc (operator, 4, num1, num2)
                    disp.Value <- "4"
                else
                    num1.Value <- "4"
                    disp.Value <- "4"
            )
            .five(fun _ ->
                if operator.Value <> "" then
                    Calc (operator, 5, num1, num2)
                    disp.Value <- "5"
                else
                    num1.Value <- "5"
                    disp.Value <- "5"
            )
            .six(fun _ ->
                if operator.Value <> "" then
                    Calc (operator, 6, num1, num2)
                    disp.Value <- "6"
                else
                    num1.Value <- "6"
                    disp.Value <- "6"
            )
            .seven(fun _ ->
                if operator.Value <> "" then
                    Calc (operator, 7, num1, num2)
                    disp.Value <- "7"
                else
                    num1.Value <- "7"
                    disp.Value <- "7"
            )
            .eight(fun _ ->
                if operator.Value <> "" then
                    Calc (operator, 8, num1, num2)
                    disp.Value <- "8"
                else
                    num1.Value <- "8"
                    disp.Value <- "8"
            )
            .nine(fun _ ->
                if operator.Value <> "" then
                    Calc (operator, 9, num1, num2)
                    disp.Value <- "9"
                else
                    num1.Value <- "9"
                    disp.Value <- "9"
            )


            // Itt vizsgáljuk az operátor gombok megnyomását, ugye itt is külön viselkedés kell akkor, ha még nem volt megnyomva és akkor, ha már igen. A függvény nevek alapján könnyen
            // beazonosítható, hogy melyik függvény miért felelõs
            
            .add(fun _ ->
                if operator.Value <> "" then
                    num1.Value <- num2.Value
                    disp.Value <- num2.Value
                    operator.Value <- "+"
                else
                    operator.Value <- "+"
            )
            
            .neg(fun _ ->
                if operator.Value <> "" then
                    num2.Value <- num1.Value
                    num2.Value <- (-(float num2.Value)).ToString()
                    disp.Value <- num2.Value
                    num1.Value <- num2.Value
                    operator.Value <- "+-"
                else
                    num1.Value <- (-(float num1.Value)).ToString()
                    disp.Value <- num1.Value
                    operator.Value <- "+-"
            )
            .sub(fun _ ->
                if operator.Value <> "" then
                    num1.Value <- num2.Value
                    disp.Value <- num2.Value
                    operator.Value <- "-"
                else
                    operator.Value <- "-"
            )
            .mult(fun _ ->
                if operator.Value <> "" then
                    num1.Value <- num2.Value
                    disp.Value <- num2.Value
                    operator.Value <- "*"
                else
                    operator.Value <- "*"
            )
            .div(fun _ ->
                if operator.Value <> "" then
                    num1.Value <- num2.Value
                    disp.Value <- num2.Value
                    operator.Value <- "/"
                else
                    operator.Value <- "/"
            )
            
            // Itt végezzük a törléseket

            .C(fun _ ->
                Cleardisp()
            )
            
            .AC(fun _ ->
                Clearnum1()
                Clearnum2()
                Clearop()
                Cleardisp()
            )

            
            // Ez az egyenlõség jel gomb vezérlése
            
            .equ(fun _ ->
                num1.Value <- num2.Value
                disp.Value <- num2.Value
            )

            // Ezek itt az extra pontot érõ részek, sin, cos és 1/x, amit flip-nek neveztem el.
            
            .sin(fun _ ->
                if operator.Value <> "" then
                    operator.Value <- "sin"
                    num1.Value <- num2.Value
                    disp.Value <- num2.Value
                    Calc (operator, 0, num1, num2)
                    disp.Value <- num1.Value
                    num2.Value <- num1.Value
                    
                else
                    operator.Value <- "sin"
                    Calc (operator, 0, num1, num2)
                    disp.Value <- num1.Value
                    num2.Value <- num1.Value
            )
            .cos(fun _ ->
                if operator.Value <> "" then
                    operator.Value <- "cos"
                    num1.Value <- num2.Value
                    disp.Value <- num2.Value
                    Calc (operator, 0, num1, num2)
                    disp.Value <- num1.Value
                    num2.Value <- num1.Value
                    
                else
                    operator.Value <- "cos"
                    Calc (operator, 0, num1, num2)
                    disp.Value <- num1.Value
                    num2.Value <- num1.Value
            )
            
            .flip(fun _ ->
                if operator.Value <> "" then
                    operator.Value <- "1/"
                    num1.Value <- num2.Value
                    disp.Value <- num2.Value
                    Calc (operator, 0, num1, num2)
                    disp.Value <- num1.Value
                    num2.Value <- num1.Value
                    
                else
                    operator.Value <- "1/"
                    Calc (operator, 0, num1, num2)
                    disp.Value <- num1.Value
                    num2.Value <- num1.Value
            )
            


            
            .Doc()
        |> Doc.RunById "main"
