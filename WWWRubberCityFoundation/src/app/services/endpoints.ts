export const endpoints = {
    base:{
        localAPI: 'http://localhost:30966'
    },
    
    homeController:{
        home: 'http://localhost:30966/home'
    },

    usersController:{
        add: 'http://localhost:30966/users/add'
    },

    helpRequestController:{
        add: 'http://localhost:30966/helprequest/add'
    },

    dashboardController:{
        get: 'http://localhost:30966/helpers/dashboard'
    },
    
    authenticationController:{
        login: 'http://localhost:30966/authentication/login'
    }
}