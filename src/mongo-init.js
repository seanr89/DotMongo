db.createUser({
    user: 'sean',
    pwd: 'password',
    roles: [
        {
            role: 'readWrite',
            db: 'EventDb',
        },
    ],
});
