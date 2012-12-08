/*
Copyright (c) 2003-2012, CKSource - Frederico Knabben. All rights reserved.
For licensing, see LICENSE.html or http://ckfinder.com/license
*/

CKFinder.customConfig = function( config )
{
	// Define changes to default configuration here.
	// For the list of available options, check:
	// http://docs.cksource.com/ckfinder_2.x_api/symbols/CKFinder.config.html

	// Sample configuration options:
	// config.uiColor = '#BDE31E';
	// config.language = 'fr';
	// config.removePlugins = 'basket';
};
CKEDITOR.editorConfig = function (config) {
    // Define changes to default configuration here. For example:
    config.language = 'zh-cn'; //中文
    // config.uiColor = '#AADC6E';

    //在 CKEditor 中集成 CKFinder，注意 ckfinder 的路径选择要正确。
    var ckfinderPath = ""; //ckfinder路径
    config.filebrowserBrowseUrl = ckfinderPath + '/ckfinder/ckfinder.html';
    config.filebrowserImageBrowseUrl = ckfinderPath + '/ckfinder/ckfinder.html?type=Images';
    config.filebrowserFlashBrowseUrl = ckfinderPath + '/ckfinder/ckfinder.html?type=Flash';
    config.filebrowserUploadUrl = ckfinderPath + '/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Files';
    config.filebrowserImageUploadUrl = ckfinderPath + '/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Images';
    config.filebrowserFlashUploadUrl = ckfinderPath + '/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Flash';

};