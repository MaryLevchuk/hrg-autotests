using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpers
{
    public static class Locators
    {   
        //Menu
        public static string ExploreMenuItem = ".inspiration";
       
        public static string MenuPanel = ".drawer";
        public static string MenuLogo = "#logo";
        public static string MenuPrimaryItems = ".nav-global-primary li";
        public static string MenuSecondaryItems = ".nav-global-secondary li";
        public static string MenuLanguageSelector = ".global-settings-language";

        //Footer
        public static string FooterPanel = ".main-footer";
        public static string FooterSocialIcons = "a.icon.icon-only";   
        public static string FooterSocialIconsText = ".footer-social-media-title";
        public static string FooterInfoList = ".footer-info-list";
        public static string FooterCopyright = ".footer-info-copyright";
        public static string FooterLogoListItems = ".footer-logo-list li";
        public static string FooterArrowUp = ".footer-back-to-top";

        //InspirationPage
        public static string FilterIconsList = ".inspiration-filter-nav-tab-icon";
        public static string FilterTitlesList = ".title";
        public static string FilterOptionsList = ".form-label.form-label-checkbox";
        public static string ClearAllFiltersBtn = ".grid-filter-clear-all";
        public static string SearchInput = ".filter-search #inspiration-search";
        public static string SearchBtn = ".filter-search-button";
        public static string FirstArticle = ".grid-item.wow.zoomIn.wow-animated.animated.animated";
        public static string ArticlesList = ".grid-item-media-wrapper";
        public static string InspirationHeader = ".header-primary";
        public static string InspirationIntro = ".excerpt";
        public static string LastVisibleArticle = ".grid-item.wow.zoomIn.wow-animated.animated.animated:nth-child(5)";


        //HomePage
        public static string BackgroudImageDiv = ".homepage-bg";
        public static string Header = ".center";
        public static string Intro = ".excerpt.inverted.step3";
        public static string FindAnAdventureBtn = ".link.step4";
        public static string PromotedTravels = ".homepage-promoted-travels";
    }
}
