import './App.css';
import "bootstrap/dist/css/bootstrap.min.css";
import { BrowserRouter, Routes, Route } from "react-router-dom";
import Auth from "./Auth/Auth";
import Main from "./Main/Main"
import Todos from "./Todos/Todos";

function App() {
  return (
      <BrowserRouter>
        <Routes>
            <Route path="/" element={<Main />}></Route>
            <Route path="/auth" element={<Auth />} />
            <Route path="/todos" element={<Todos />}/>
        </Routes>
      </BrowserRouter>
  );
}

export default App;
