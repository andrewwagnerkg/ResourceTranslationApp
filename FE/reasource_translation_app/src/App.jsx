import {BrowserRouter, Navigate, Route, Routes} from "react-router";
import Layout from "./Pages/Layout.jsx";
import NofFoundPage from "./Pages/NofFoundPage/index.jsx";
import LoginPage from "./Pages/LoginPage/index.jsx";
import DashboardPage from "./Pages/DashboardPage/index.jsx";
import ResourcesPage from "./Pages/ResourcesPage/index.jsx";
import LanguagesPage from "./Pages/LanguagesPage/index.jsx";
import TransalationsPage from "./Pages/TransalationsPage/index.jsx";
import {ProtectedRoute} from "./Components/ProtectedRoute.jsx";

function App() {

  return (
      <BrowserRouter>
          <Routes>
              <Route path="/" element={<Layout/>}>
                  <Route index element={<LoginPage/>}/>
                  <Route path="login" element={<Navigate to="/"/>}/>
                      <Route path="dashboard" element={
                          <ProtectedRoute auth={false}>
                                <DashboardPage/>
                          </ProtectedRoute>}>
                          <Route index element={<ResourcesPage/>}/>
                          <Route path="languages" element={<LanguagesPage/>}/>
                          <Route path="translations" element={<TransalationsPage/>}/>
                      </Route>
                  <Route path="logout" element={<Navigate to="/"/>}/>
                  <Route path="*" element={<NofFoundPage/>} />
              </Route>
          </Routes>
          </BrowserRouter>
  )
}

export default App
