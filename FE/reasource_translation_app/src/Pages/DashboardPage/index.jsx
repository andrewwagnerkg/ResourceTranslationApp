import {NavLink, Outlet} from "react-router";

function DashboardPage() {
    return (
        <>
            <header>
                <ul>
                    <li><NavLink to="">Resources</NavLink></li>
                    <li><NavLink to="languages">Languages</NavLink></li>
                    <li><NavLink to="translations">Transalations</NavLink></li>
                    <li><NavLink to="/logout">Logout</NavLink></li>
                </ul>
            </header>
            <Outlet/>
        </>
    )
}

export default DashboardPage;