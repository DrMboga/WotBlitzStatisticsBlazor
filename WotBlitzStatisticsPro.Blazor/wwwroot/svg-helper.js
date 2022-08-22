var svgHelper = svgHelper || {};

svgHelper.CalculateTextBlockDimensions = function (textParams) {
    const svg = `
    <svg xmlns="http://www.w3.org/2000/svg">
            <text 
             x="0"
             y="0"
             text-anchor="start" 
             alignment-baseline="before-edge"
             font-family="${textParams.Font}" 
             font-size="${textParams.Size}">
                    ${textParams.Text}
            </text>
    </svg>`;
    const el = document.createElement("div");
    el.innerHTML = svg;
    document.body.appendChild(el);
    const svgText = el.querySelector('text').getBBox();
    el.remove();
    const result = { Height: Math.round(svgText.height), Width: Math.round(svgText.width) };
    return result;
};