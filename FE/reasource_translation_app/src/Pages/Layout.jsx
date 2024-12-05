import {Outlet} from "react-router";

function Layout() {
    return (
        <>
            <main>
                <Outlet/>
            </main>
            <footer>
                AV2024
            </footer>
        </>
    )
}

export default Layout;