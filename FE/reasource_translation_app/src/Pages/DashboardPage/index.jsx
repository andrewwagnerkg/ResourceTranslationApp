import {NavLink, Outlet} from "react-router";
import {Container, Nav, Navbar} from "react-bootstrap";

function DashboardPage() {
    return (
        <>
            <Navbar bg="primary" data-bs-theme="dark">
                <Container>
                    <Navbar.Brand>Resources Dashboard</Navbar.Brand>
                    <Nav className="me-auto">
                        <NavLink to="" className="link-light nav-link">Resources</NavLink>
                        <NavLink to="languages" className="link-light nav-link">Languages</NavLink>
                            <NavLink to="translations" className="link-light nav-link">Transalations</NavLink>
                    </Nav>
                    <Navbar.Toggle />
                    <Navbar.Collapse className="justify-content-end">
                        <NavLink to="/logout" className="link-light nav-link">Logout</NavLink>
                    </Navbar.Collapse>
                </Container>
            </Navbar>
            <div className="vh-100">
                <Container>
                    <Outlet/>
                </Container>
            </div>
        </>
    )
}

export default DashboardPage;