var mediaQueries = mediaQueries || {};

mediaQueries.IsScreenWidthLessThen = function (width) {
    let mql = window.matchMedia(`(max-width: ${width}px)`);
    return mql.matches;
};