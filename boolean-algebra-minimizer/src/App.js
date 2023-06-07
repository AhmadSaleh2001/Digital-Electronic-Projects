import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import Navbar from "./components/Navbar";
import Footer from "./components/Footer";
import MinTerm from "./pages/MinTerm";
import Error from "./components/Error";
import BooleanFunction from "./pages/BooleanFunction";
import HowToUse from "./pages/HowToUse";
import "./BackEnd.css";

let App = () => {
  return (
    <div>
      <Router>
        <Navbar />
        <Routes>
          <Route exact path="/" element={<MinTerm />} />
          <Route path="/BooleanFunction" element={<BooleanFunction />} />
          <Route path="/HowToUse" element={<HowToUse />} />
          <Route path="*" element={<Error />} />
        </Routes>
      </Router>

      <Footer />
    </div>
  );
};

export default App;
