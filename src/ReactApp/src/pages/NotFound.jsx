const NotFound = () => {
    const backgroundStyles = {       
        backgroundImage: `url('assets/404.jpg')`,
        backgroundSize: 'cover',
        backgroundPosition: 'center',
        backgroundRepeat: 'no-repeat',
    };

    return (
        <div className="container-fluid d-flex align-items-center justify-content-center vh-100" style={backgroundStyles}>           
        </div>
    );
};

export default NotFound;
