import { useState } from "react";
let HowToUse = () => {
  let [Idx, SetIdx] = useState(1);
  let Helps = [
    {
      id: 1,
      Messages: [
        "Dont Add Any Spaces Between MinTerms",
        "Enter MinTerms Between 0 And 2^(NumberOfLiterals) - 1",
      ],
      Example: "MinTerms : 1 5 8 9 10 => Write Them Like This 1,5,8,9,10",
    },
    {
      id: 2,
      Messages: [
        "Dont Add Any Spaces",
        "Enter Function With Letters Upper Case",
        "Write ' ! ' Before Variable You Want To Negate It --> If You Need To Negate B This Term ABC Write It Like This A!BC",
      ],
      Example: "ABC' + AB'C + CD  Write It Like This AB!C+A!BC+CD",
    },
  ];
  return (
    <div className="HowToUse">
      <div className="container">
        <div className="Links">
          <button
            onClick={() => SetIdx(1)}
            className={Idx === 1 ? "Active" : ""}
          >
            MinTerms
          </button>
          <button
            onClick={() => SetIdx(2)}
            className={Idx === 2 ? "Active" : ""}
          >
            Boolean Function
          </button>
        </div>
        <div>
          {Helps.filter((Item) => Item.id === Idx).map((Item, Idx) => {
            return (
              <div key={Idx}>
                <ul>
                  {Item.Messages.map((Msg, Idx2) => (
                    <li key={Idx2}>{Msg}</li>
                  ))}
                </ul>
                <h3>
                  <span style={{ color: "red" }}>Example : </span>
                  {Item.Example}
                </h3>
              </div>
            );
          })}
        </div>
      </div>
    </div>
  );
};

export default HowToUse;
