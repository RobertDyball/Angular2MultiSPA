"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
var core_1 = require('@angular/core');
var platform_browser_1 = require('@angular/platform-browser');
var Category_service_1 = require('./services/Category.service');
var Product_service_1 = require('./services/Product.service');
var ContentComponent = (function () {
    function ContentComponent(_DomSanitizer, productService, categoryService) {
        this._DomSanitizer = _DomSanitizer;
        this.productService = productService;
        this.categoryService = categoryService;
        this.categories = [];
        this.products = [];
        this.selectedCategory = null;
    }
    ContentComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.categoryService.getCategories()
            .subscribe(function (data) { return _this.categories = data; });
        this.presetToFirstItem();
    };
    ContentComponent.prototype.presetToFirstItem = function () {
        if (this.selectedCategory === null && this.categories.length > 0) {
            this.selectCategory(this.categories[0]);
        }
    };
    ContentComponent.prototype.selectCategory = function (category) {
        var _this = this;
        this.selectedCategory = category;
        this.products = [];
        this.productService.getProducts(this.selectedCategory.id)
            .subscribe(function (data) { return _this.products = data; });
    };
    ContentComponent.prototype.getClass = function (category) {
        this.presetToFirstItem();
        return (this.selectedCategory != null && (this.selectedCategory.id === category.id)) ? "active" : "";
    };
    ContentComponent = __decorate([
        core_1.Component({
            selector: 'my-content',
            templateUrl: '/partial/contentComponent'
        }), 
        __metadata('design:paramtypes', [platform_browser_1.DomSanitizer, Product_service_1.ProductService, Category_service_1.CategoryService])
    ], ContentComponent);
    return ContentComponent;
}());
exports.ContentComponent = ContentComponent;
//# sourceMappingURL=content.component.js.map