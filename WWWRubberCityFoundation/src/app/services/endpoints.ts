export const endpoints = {
    base:{
        localAPI: 'http://localhost:30966'
    },
    
    homeController:{
        home: 'http://localhost:30966/home'
    },

    usersController:{
        add: 'http://localhost:30966/users/add',
        saveProfilePicture: 'http://localhost:30966/users/saveProfilePicture'
    },

    helpRequestController:{
        add: 'http://localhost:30966/helprequest/add'
    },

    dashboardController:{
        get: 'http://localhost:30966/helpers/dashboard'
    },
    
    authenticationController:{
        login: 'http://localhost:30966/login'
    },

    eventsController:{
        getAll:'http://localhost:30966/events/getAll',
        getByID:'http://localhost:30966/events/getByID',
        update:'http://localhost:30966/events/update',
        delete:'http://localhost:30966/events/delete',
        add: 'http://localhost:30966/events/add'
    },

    donationsController:{
        getAll:'http://localhost:30966/donations/getAll',
        getByID:'http://localhost:30966/donations/getByID',
        update:'http://localhost:30966/donations/update',
        delete:'http://localhost:30966/donations/delete',
        add: 'http://localhost:30966/donations/add',
        paypalCreate: 'http://localhost:30966/donations/create-paypal-transaction',
        paypalExecute: 'http://localhost:30966/donations/execute-paypal-transaction'
    }
}