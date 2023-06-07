import { useState } from "react";
import DecimalToBinary from "../Helper/DecimalToBinary";
import QuineMcClusky from "../Helper/QuineMcClusky";
import Modal from "../components/Modal";
let BooleanFunction = () => {
  let [Fn, SetFn] = useState("");
  let [Ans, SetAns] = useState("");
  let [Error, SetError] = useState(false);
  let [Message, SetMessage] = useState("");
  let [AllTerms, SetAllTerms] = useState([]);
  let ChangeStateError = () => {
    SetError(!Error);
  };
  let Solve = () => {
    let Terms = Fn.split("+");
    let All = new Set();
    let TempAllTerms = [];
    if (!Fn.length) {
      SetAns("No Need Circut => Answer Function Is 0");
      return;
    }
    for (let i = 0; i < Fn.length; i++) {
      if (Fn[i] === " ") {
        SetMessage("Please No Spaces Between Terms OR Between Literals :)");
        SetError(!Error);
        return;
      } else if (Fn[i] >= "0" && Fn[i] <= "9") {
        SetMessage("Please Enter Only Literals(Characters)");
        SetError(!Error);
        return;
      } else if (Fn[i] >= "a" && Fn[i] <= "z") {
        SetMessage("Please Enter Only CAPITAL Letters");
        SetError(!Error);
        return;
      }
      if (Fn[i] >= "A" && Fn[i] <= "Z") All.add(Fn[i]);
    }
    All = new Set([...All].sort());

    let MySort = (X) => {
      let Literals = [];
      let Curr = "";
      for (let i = 0; i < X.length; i++) {
        Curr += X[i];
        if (X[i] >= "A" && X[i] <= "Z") {
          Literals.push(Curr);
          Curr = "";
        }
      }
      Literals.sort((A, B) => {
        let C1 = A.length === 2 ? A[1] : A[0];
        let C2 = B.length === 2 ? B[1] : B[0];
        if (C1 < C2) return -1;
        else if (C1 > C2) return 1;
        return 0;
      });
      return Literals.join("");
    };

    let SolveNeed = (Term, All) => {
      let DontHave = [];
      All.forEach((X) => {
        let Idx = Term.indexOf(X);
        if (!~Idx) DontHave.push(X);
      });
      let L = DontHave.length;
      for (let i = 0; i < 1 << L; i++) {
        let TTerm = Term;
        for (let j = 0; j < L; j++) {
          if (!((1 << j) & i)) TTerm += "!";
          TTerm += DontHave[j];
        }
        TTerm = MySort(TTerm);
        TempAllTerms.push(TTerm);
      }
    };

    for (let X of Terms) SolveNeed(X, All);
    Terms = [...new Set(TempAllTerms)].sort();
    let BinaryArray = [];
    let HaveTerms = [];
    for (let X of Terms) {
      let MinL = X.length - 1;
      let Value = 0;
      let Cnt = 1;
      while (~MinL) {
        if (X[MinL] === "!") {
          MinL--;
          continue;
        }
        if (MinL - 1 >= 0) {
          if (X[MinL - 1] !== "!") Value += Cnt;
        } else Value += Cnt;
        Cnt <<= 1;
        MinL--;
      }
      // console.log(X + " " + Value);
      HaveTerms.push({ X, Value });
      let MinBinary = DecimalToBinary(Value);
      while (MinBinary.length !== All.size) MinBinary = "0" + MinBinary;
      BinaryArray.push(MinBinary);
    }
    SetAllTerms(HaveTerms);
    let TAns = QuineMcClusky(BinaryArray, All);
    SetAns(TAns.substring(0, TAns.length - 2));
  };
  return (
    <div className="BooleanFunction MinTerms">
      <div className="container">
        {Error && (
          <Modal Message={Message} ChangeStateError={ChangeStateError} />
        )}
        <h1>Boolean Function</h1>
        <div className="Item">
          <label htmlFor="">Enter Boolean Function</label>
          <textarea
            value={Fn}
            cols="50"
            onChange={(E) => SetFn(E.target.value)}
          >
            {Fn}
          </textarea>
          <button onClick={() => Solve()}>Solve</button>
        </div>

        {Ans && (
          <div>
            <div className="Item">
              <div>
                <h1 style={{ color: "var(--SecondColor)" }}>All Min Terms</h1>
                {AllTerms.map((Item, Idx) => {
                  return (
                    <div key={Idx}>
                      <h4>
                        {Item.X} = {Item.Value}
                      </h4>
                    </div>
                  );
                })}
              </div>
            </div>
            <div className="Item">
              <h3>Ans : {Ans}</h3>
            </div>
          </div>
        )}
      </div>
    </div>
  );
};

export default BooleanFunction;
