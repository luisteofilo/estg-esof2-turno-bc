window.logUser = (userId) => {
    sessionStorage.setItem('selectedUserId', userId);
    
    window.location.href = '/vinhotinder';
};
