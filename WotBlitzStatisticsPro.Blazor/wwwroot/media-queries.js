var mediaQueries = mediaQueries || {};

mediaQueries.IsScreenWidthLessThen = function (width) {
    let mql = window.matchMedia(`(max-width: ${width}px)`);
    return mql.matches;
};

mediaQueries.ScreenWidth = function () {
    return window.innerWidth;
}

mediaQueries.ScreenHeight = function () {
    return window.innerHeight;
}