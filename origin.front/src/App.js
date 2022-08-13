import {
  BrowserRouter,
  Routes,
  Route
} from "react-router-dom";
import Home from "./Home"
import Operations from "./Operations";
import Pin from "./Pin"

const App = () => (

  <BrowserRouter>
    <Routes>
      <Route path="/" element={<Home />} />
      <Route exact path="/:id" element={<Pin />} />
      <Route exact path="operations/:id" element={<Operations />} />
    </Routes>
  </BrowserRouter>
)

export default App;
