// // Authentication module for Travel Explorer
class Auth {
    constructor() {
        this.users = JSON.parse(localStorage.getItem("users") || "[]");
        this.currentUser = JSON.parse(
            localStorage.getItem("currentUser") || "null"
        );
        this.isLoggedIn = !!this.currentUser;
    }

 
    // Logout user
    logout() {
        this.currentUser = null;
        this.isLoggedIn = false;
        localStorage.removeItem("currentUser");
        localStorage.removeItem("isLoggedIn");

        return { success: true, message: "Logout successful!" };
    }

    // Get current user
    getCurrentUser() {
        return this.currentUser;
    }

    // Check if user is logged in
    isUserLoggedIn() {
        return this.isLoggedIn;
    }

    // Get all users (for admin)
    getAllUsers() {
        return this.users;
    }

    // Create admin account
    createAdminAccount() {
        const adminExists = this.users.find((user) => user.isAdmin);
        if (adminExists) {
            return { success: false, message: "Admin account already exists" };
        }

        const adminUser = {
            id: "admin-" + Date.now().toString(),
            fullName: "Admin User",
            email: "admin@travelexplorer.com",
            phone: "123-456-7890",
            password: "admin123",
            birthDate: "1990-01-01",
            registrationDate: new Date().toISOString(),
            isAdmin: true,
        };

        this.users.push(adminUser);
        localStorage.setItem("users", JSON.stringify(this.users));
        return { success: true, message: "Admin account created successfully!" };
    }
}

// Global auth instance
const auth = new Auth();

// Navigation update function
function updateNavigation() {
    const navMenu = document.querySelector(".nav-menu");
    if (!navMenu) return;

    const isLoggedIn = auth.isUserLoggedIn();
    const currentUser = auth.getCurrentUser();

    // Clear existing menu items
    navMenu.innerHTML = "";

    // Add common menu items
    const commonItems = [
        { href: "index.html", text: "Home" },
        { href: "destinations.html", text: "Orders" },
        { href: "tours.html", text: "Cart" },
        { href: "about.html", text: "About" },
    ];

    commonItems.forEach((item) => {
        const li = document.createElement("li");
        const a = document.createElement("a");
        a.href = item.href;
        a.textContent = item.text;

        // Set active class based on current page
        if (window.location.pathname.includes(item.href)) {
            a.classList.add("active");
        }

        li.appendChild(a);
        navMenu.appendChild(li);
    });

    // Add authentication menu items
    if (isLoggedIn) {
        // User is logged in - show user menu and logout
        const userLi = document.createElement("li");
        const userA = document.createElement("a");
        userA.href = "#";
        const userText = currentUser.isAdmin
            ? `Admin: ${currentUser.fullName.split(" ")[0]}`
            : `Welcome, ${currentUser.fullName.split(" ")[0]}`;
        userA.textContent = userText;
        userA.style.color = currentUser.isAdmin ? "#e74c3c" : "#3498db";
        userLi.appendChild(userA);
        navMenu.appendChild(userLi);

        const logoutLi = document.createElement("li");
        const logoutA = document.createElement("a");
        logoutA.href = "logout.html";
        logoutA.textContent = "Logout";
        logoutA.onclick = function (e) {
            e.preventDefault();
            auth.logout();
            window.location.href = "index.html";
        };
        logoutLi.appendChild(logoutA);
        navMenu.appendChild(logoutLi);
    } else {
        // User is not logged in - show login and register
        const loginLi = document.createElement("li");
        const loginA = document.createElement("a");
        loginA.href = "login.html";
        loginA.textContent = "Login";
        if (window.location.pathname.includes("login.html")) {
            loginA.classList.add("active");
        }
        loginLi.appendChild(loginA);
        navMenu.appendChild(loginLi);

        const registerLi = document.createElement("li");
        const registerA = document.createElement("a");
        registerA.href = "register.html";
        registerA.textContent = "Register";
        if (window.location.pathname.includes("register.html")) {
            registerA.classList.add("active");
        }
        registerLi.appendChild(registerA);
        navMenu.appendChild(registerLi);
    }
}

// Initialize navigation on page load
document.addEventListener("DOMContentLoaded", function () {
    // Create admin account if it doesn't exist
    const adminResult = auth.createAdminAccount();
    if (adminResult.success) {
        console.log("Admin account created:", adminResult.message);
    }

    updateNavigation();
});
