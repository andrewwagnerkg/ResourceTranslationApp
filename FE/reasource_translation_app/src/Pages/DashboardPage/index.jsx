import {NavLink, Outlet} from "react-router";
import {Container, Nav, Navbar} from "react-bootstrap";

function DashboardPage() {
    return (
        <>
            <Navbar bg="primary" data-bs-theme="dark">
                <Container>
                    <Navbar.Brand>Resources Dashboard</Navbar.Brand>
                    <Nav className="me-auto">
                        <Nav.Link><NavLink to="" className="link-light">Resources</NavLink></Nav.Link>
                        <Nav.Link><NavLink to="languages" className="link-light">Languages</NavLink></Nav.Link>
                            <Nav.Link><NavLink to="translations" className="link-light">Transalations</NavLink></Nav.Link>
                    </Nav>
                    <Navbar.Toggle />
                    <Navbar.Collapse className="justify-content-end">
                        <Nav.Link><NavLink to="/logout" className="link-light">Logout</NavLink></Nav.Link>
                    </Navbar.Collapse>
                </Container>
            </Navbar>
            <div className="vh-100">
                <Outlet/>
            </div>
        </>
    )
}

export default DashboardPage;