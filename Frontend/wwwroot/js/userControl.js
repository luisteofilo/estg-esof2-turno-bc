window.selectUser = (userId) => {
    sessionStorage.setItem('selectedUserId', userId);
    
    window.location.href = '/vinhotinder';
};
