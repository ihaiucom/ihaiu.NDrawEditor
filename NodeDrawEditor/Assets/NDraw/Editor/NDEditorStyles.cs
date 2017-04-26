using System;
using System.ComponentModel;
using UnityEditor;
using UnityEngine;

namespace ihaiu.NDraws
{
    [Localizable(false)]
    public static class NDEditorStyles
    {
        public enum ColorScheme
        {
            Default,
            DarkBackground,
            LightBackground
        }
        public const string toolbarSearchTextFieldStyle = "ToolbarSeachTextField";
        public const string toolbarSeachCancelButtonStyle = "ToolbarSeachCancelButton";
        public const string buttonStyle = "Button";
        public const string labelStyle = "Label";
        public const string toggleStyle = "Toggle";
        public const string boxStyle = "Box";
        public const string newline = "\n";
        public const string tab = "\t";
        public const string tab2 = "\t\t";
        public const float DefaultStateRowHeight = 16f;
        public const float StateMinWidth = 100f;
        public const float StateMaxWidth = 400f;
        public const float StateWidthPadding = 20f;
        public const float DescriptionHeight = 44f;
        public const float MaxFsmDescriptionWidth = 200f;
        private static bool usingProSkin;
        public static float StateRowHeight = 16f;
        public static readonly Color ErrorTextColor = new Color(1f, 0f, 0f);
        public static readonly Color ErrorTextColorIndie = new Color(0.8f, 0f, 0f);
        public static readonly Color[] LinkColors = new Color[]
            {
                new Color(0.1f, 0.1f, 0.1f),
                new Color(0.24f, 0.38f, 0.57f),
                new Color(0.06f, 0.44f, 0.06f),
                new Color(1f, 0f, 0f),
                new Color(1f, 0f, 0f),
                new Color(0.8f, 0.8f, 0f)
            };
        public static Color[] HighlightColors = new Color[6];
        public static readonly Color[] ActionColors = new Color[]
            {
                new Color(1f, 1f, 1f),
                new Color(1f, 1f, 1f),
                new Color(0.06f, 1f, 0.06f),
                new Color(1f, 0f, 0f),
                new Color(1f, 1f, 1f),
                new Color(0.8f, 0.8f, 0f)
            };
        public static readonly float[] LinkWidths = new float[]
            {
                1.5f,
                3f,
                3f,
                3f,
                3f,
                1.5f
            };
        private static Color graphTextColor;
        private static float initScale;
        private static bool scaleInitialized;
        private static bool initialized;
        private static Texture2D[] gameStateIcons;
        private static GUIStyle[] logTypeStyles;
        public static Color DefaultBackgroundColor = new Color(0.3f, 0.3f, 0.3f);
        public static Color LabelTextColor
        {
            get;
            private set;
        }
        public static Texture2D SelectedBG
        {
            get;
            private set;
        }
        public static GUIStyle TimelineLabelLeft
        {
            get;
            private set;
        }
        public static GUIStyle TimelineLabelRight
        {
            get;
            private set;
        }
        public static GUIStyle TimelineBarText
        {
            get;
            private set;
        }
        public static GUIStyle TimelineDebugLine
        {
            get;
            private set;
        }
        public static GUIStyle TimelineBar
        {
            get;
            private set;
        }
        public static GUIStyle DarkPreviewBg
        {
            get;
            private set;
        }
        public static GUIStyle RightAlignedLabel
        {
            get;
            private set;
        }
        public static GUIStyle ColorSwatch
        {
            get;
            private set;
        }
        public static GUIStyle CenteredLabel
        {
            get;
            private set;
        }
        public static GUIStyle LabelWithWordWrap
        {
            get;
            private set;
        }
        public static GUIStyle BoldLabelWithWordWrap
        {
            get;
            private set;
        }
        public static GUIStyle ActionPreviewTitle
        {
            get;
            private set;
        }
        public static GUIStyle ToolbarTab
        {
            get;
            private set;
        }
        public static GUIStyle TextAreaWithWordWrap
        {
            get;
            private set;
        }
        public static GUIStyle Background
        {
            get;
            private set;
        }
        public static GUIStyle InnerGlowBox
        {
            get;
            private set;
        }
        public static GUIStyle SelectionBox
        {
            get;
            private set;
        }
        public static GUIStyle DropShadowBox
        {
            get;
            private set;
        }
        public static GUIStyle SinglePixelFrame
        {
            get;
            private set;
        }
        public static GUIStyle SelectionRect
        {
            get;
            private set;
        }
        public static GUIStyle StateBox
        {
            get;
            private set;
        }
        public static GUIStyle StateTitleBox
        {
            get;
            private set;
        }
        public static GUIStyle StateTitleLongBox
        {
            get;
            private set;
        }
        public static GUIStyle TransitionBox
        {
            get;
            private set;
        }
        public static GUIStyle TransitionBoxSelected
        {
            get;
            private set;
        }
        public static GUIStyle GlobalTransitionBox
        {
            get;
            private set;
        }
        public static GUIStyle StartTransitionBox
        {
            get;
            private set;
        }
        public static GUIStyle BreakpointOff
        {
            get;
            private set;
        }
        public static GUIStyle BreakpointOn
        {
            get;
            private set;
        }
        public static Texture2D LineTexture
        {
            get;
            private set;
        }
        public static Texture2D TitleIcon
        {
            get;
            private set;
        }
        public static Texture2D LeftArrow
        {
            get;
            private set;
        }
        public static Texture2D RightArrow
        {
            get;
            private set;
        }
        public static Texture2D StartArrow
        {
            get;
            private set;
        }
        public static Texture2D GlobalArrow
        {
            get;
            private set;
        }
        public static Texture2D StateErrorIcon
        {
            get;
            private set;
        }
        public static Texture2D BroadcastIcon
        {
            get;
            private set;
        }
        public static GUIStyle Divider
        {
            get;
            private set;
        }
        public static GUIStyle DividerSequence
        {
            get;
            private set;
        }
        public static GUIStyle ActionFoldout
        {
            get;
            private set;
        }
        public static GUIStyle ActionToggle
        {
            get;
            private set;
        }
        public static GUIStyle ActionTitle
        {
            get;
            private set;
        }
        public static GUIStyle ActionTitleError
        {
            get;
            private set;
        }
        public static GUIStyle ActionTitleSelected
        {
            get;
            private set;
        }
        public static GUIStyle CategoryFoldout
        {
            get;
            private set;
        }
        public static GUIStyle VersionInfo
        {
            get;
            private set;
        }
        public static GUIStyle ActionErrorBox
        {
            get;
            private set;
        }
        public static GUIStyle EventBox
        {
            get;
            private set;
        }
        public static GUIStyle SelectedEventBox
        {
            get;
            private set;
        }
        public static GUIStyle TableRowHeader
        {
            get;
            private set;
        }
        public static GUIStyle TableRowBox
        {
            get;
            private set;
        }
        public static GUIStyle TableRowBoxNoDivider
        {
            get;
            private set;
        }
        public static GUIStyle ErrorBox
        {
            get;
            private set;
        }
        public static GUIStyle InfoBox
        {
            get;
            private set;
        }
        public static GUIStyle HintBox
        {
            get;
            private set;
        }
        public static GUIStyle MiniButton
        {
            get;
            private set;
        }
        public static GUIStyle MiniButtonPadded
        {
            get;
            private set;
        }
        public static GUIStyle ActionItem
        {
            get;
            private set;
        }
        public static GUIStyle ActionItemSelected
        {
            get;
            private set;
        }
        public static GUIStyle ActionLabel
        {
            get;
            private set;
        }
        public static GUIStyle ActionLabelSelected
        {
            get;
            private set;
        }
        public static GUIStyle ErrorCount
        {
            get;
            private set;
        }
        public static Texture2D NoErrors
        {
            get;
            private set;
        }
        public static Texture2D Errors
        {
            get;
            private set;
        }
        public static GUIStyle RightAlignedToolbarDropdown
        {
            get;
            private set;
        }
        public static GUIStyle ToolbarHeading
        {
            get;
            private set;
        }
        public static GUIStyle TableRow
        {
            get;
            private set;
        }
        public static GUIStyle TableRowSelected
        {
            get;
            private set;
        }
        public static GUIStyle TableRowCheckBox
        {
            get;
            private set;
        }
        public static GUIStyle LogoLarge
        {
            get;
            private set;
        }
        public static GUIStyle CommentBox
        {
            get;
            private set;
        }
        public static GUIStyle HintBoxTextOnly
        {
            get;
            private set;
        }
        public static GUIStyle TextArea
        {
            get;
            private set;
        }
        public static GUIStyle BoldFoldout
        {
            get;
            private set;
        }
        public static GUIStyle TableRowText
        {
            get;
            private set;
        }
        public static GUIStyle TableRowTextSelected
        {
            get;
            private set;
        }
        public static GUIStyle SelectedRow
        {
            get;
            private set;
        }
        public static GUIStyle InsertLine
        {
            get;
            private set;
        }
        public static GUIStyle LogBackground
        {
            get;
            private set;
        }
        public static GUIStyle LogLine
        {
            get;
            private set;
        }
        public static GUIStyle LogLine2
        {
            get;
            private set;
        }
        public static GUIStyle LogLineSelected
        {
            get;
            private set;
        }
        public static GUIStyle LogLineTimeline
        {
            get;
            private set;
        }
        public static GUIStyle InlineErrorIcon
        {
            get;
            set;
        }
        public static Color GuiContentErrorColor
        {
            get;
            private set;
        }
        public static Color GuiBackgroundErrorColor
        {
            get;
            private set;
        }
        public static Color MinimapFrameColor
        {
            get;
            private set;
        }
        public static Color MinimapViewRectColor
        {
            get;
            private set;
        }
        public static Color WatermarkTint
        {
            get;
            private set;
        }
        public static Color WatermarkTintSolid
        {
            get;
            private set;
        }
        public static Texture DefaultWatermark
        {
            get;
            private set;
        }
        public static GUIStyle Watermark
        {
            get;
            set;
        }
        public static GUIStyle LargeWatermarkText
        {
            get;
            private set;
        }
        public static GUIStyle LargeText
        {
            get;
            private set;
        }
        public static GUIStyle SmallWatermarkText
        {
            get;
            private set;
        }
        public static GUIStyle LargeTitleText
        {
            get;
            private set;
        }
        public static GUIStyle LargeTitleWithLogo
        {
            get;
            private set;
        }
        public static GUIStyle PlaymakerHeader
        {
            get;
            private set;
        }
        public static GUIStyle WelcomeLink
        {
            get;
            private set;
        }
        public static Texture BasicsIcon
        {
            get;
            private set;
        }
        public static Texture DocsIcon
        {
            get;
            private set;
        }
        public static Texture VideoIcon
        {
            get;
            private set;
        }
        public static Texture ForumIcon
        {
            get;
            private set;
        }
        public static Texture SamplesIcon
        {
            get;
            private set;
        }
        public static Texture PhotonIcon
        {
            get;
            private set;
        }
        public static Texture AddonsIcon
        {
            get;
            private set;
        }
        public static Texture BlackBerryAddonIcon
        {
            get;
            private set;
        }
        public static Texture WP8AddonIcon
        {
            get;
            private set;
        }
        public static Texture MetroAddonIcon
        {
            get;
            private set;
        }
        public static Texture BackButton
        {
            get;
            private set;
        }
        public static GUIStyle DefaultStateBoxStyle
        {
            get;
            private set;
        }
        public static Color ActiveHighlightColor
        {
            get
            {
                return NDEditorStyles.HighlightColors[2];
            }
        }
        public static Color PausedHighlightColor
        {
            get
            {
                return NDEditorStyles.HighlightColors[5];
            }
        }
        public static Color BreakpointHighlightColor
        {
            get
            {
                return NDEditorStyles.HighlightColors[4];
            }
        }
        public static GUIStyle LogInfo
        {
            get;
            private set;
        }
        [Localizable(false)]
        public static bool UsingProSkin()
        {
            return EditorGUIUtility.isProSkin;
        }
        public static bool IsInitialized()
        {
            return NDEditorStyles.initialized && NDEditorStyles.scaleInitialized && NDEditorStyles.usingProSkin == NDEditorStyles.UsingProSkin() && NDEditorStyles.LeftArrow != null;
        }
        public static void Reinitialize()
        {
            NDEditorStyles.initialized = false;
        }
        public static void Init()
        {
            if (NDEditorStyles.IsInitialized())
            {
                return;
            }
            NDEditorStyles.InitCommon();
            NDEditorStyles.usingProSkin = NDEditorStyles.UsingProSkin();
            if (NDEditorStyles.usingProSkin)
            {
                NDEditorStyles.InitProSkin();
            }
            else
            {
                NDEditorStyles.InitIndieSkin();
            }
            NDEditorContent.Init(NDEditorStyles.usingProSkin);
            NDEditorStyles.InitColorScheme(NDEditorSettings.ColorScheme);
            NDEditorStyles.SetScale(NDEditorStyles.initScale);
            NDEditorStyles.initialized = true;
        }
        private static void InitCommon()
        {
            GUIStyle gUIStyle = new GUIStyle();
            gUIStyle.normal.textColor = Color.white;
            gUIStyle.alignment = TextAnchor.MiddleLeft;
            gUIStyle.padding = new RectOffset(2, 0, 0, 1);
            NDEditorStyles.TimelineBarText = gUIStyle;

            GUIStyle gUIStyle2 = new GUIStyle(NDEditorStyles.TimelineBarText);
            gUIStyle2.normal.background = Files.LoadTextureFromDll("smallLeftArrow", 6, 20);

            gUIStyle2.normal.background = (Files.LoadTextureFromDll("smallLeftArrow", 6, 20));
            gUIStyle2.border = (new RectOffset(5, 0, 0, 0));
            gUIStyle2.padding = (new RectOffset(6, 0, 0, 1));
            NDEditorStyles.TimelineLabelLeft = gUIStyle2;

            GUIStyle gUIStyle3 = new GUIStyle(NDEditorStyles.TimelineBarText);
            gUIStyle3.normal.background = (Files.LoadTextureFromDll("smallRightArrow", 6, 20));
            gUIStyle3.border = (new RectOffset(0, 5, 0, 0));
            gUIStyle3.padding = (new RectOffset(0, 6, 0, 1));
            NDEditorStyles.TimelineLabelRight = gUIStyle3;
            GUIStyle gUIStyle4 = new GUIStyle();
            gUIStyle4.normal.background = (Files.LoadTextureFromDll("whiteVertical", 5, 2));
            gUIStyle4.normal.textColor = Color.white;
            gUIStyle4.fixedWidth = (5f);
            NDEditorStyles.TimelineDebugLine = gUIStyle4;
            GUIStyle gUIStyle5 = new GUIStyle();
            gUIStyle5.normal.background = (Files.LoadTextureFromDll("timelineBar", 4, 16));
            gUIStyle5.border = (new RectOffset(1, 1, 1, 1));
            NDEditorStyles.TimelineBar = gUIStyle5;
            GUIStyle gUIStyle6 = new GUIStyle();
            gUIStyle6.normal.background = (Files.LoadTextureFromDll("darkPreviewBg", 32, 32));
            gUIStyle6.border = (new RectOffset(13, 13, 13, 13));
            NDEditorStyles.DarkPreviewBg = gUIStyle6;
            GUIStyle gUIStyle7 = new GUIStyle("Box");
            gUIStyle7.normal.background = (Files.LoadTextureFromDll("swatchBox", 16, 16));
            gUIStyle7.border = (new RectOffset(2, 2, 2, 2));
            NDEditorStyles.ColorSwatch = gUIStyle7;
            GUIStyle gUIStyle8 = new GUIStyle(EditorStyles.label);
            gUIStyle8.alignment = TextAnchor.MiddleRight;
            NDEditorStyles.RightAlignedLabel = gUIStyle8;
            GUIStyle gUIStyle9 = new GUIStyle(EditorStyles.label);
            gUIStyle9.alignment = TextAnchor.MiddleCenter;
            NDEditorStyles.CenteredLabel = gUIStyle9;
            GUIStyle gUIStyle10 = new GUIStyle(EditorStyles.textField);
            gUIStyle10.wordWrap = (true);
            NDEditorStyles.TextAreaWithWordWrap = gUIStyle10;
            GUIStyle gUIStyle11 = new GUIStyle(EditorStyles.label);
            gUIStyle11.wordWrap = (true);
            NDEditorStyles.LabelWithWordWrap = gUIStyle11;
            GUIStyle gUIStyle12 = new GUIStyle(EditorStyles.boldLabel);
            gUIStyle12.wordWrap = (true);
            NDEditorStyles.BoldLabelWithWordWrap = gUIStyle12;
            GUIStyle gUIStyle13 = new GUIStyle(EditorStyles.textField);
            gUIStyle13.wordWrap = (true);
            NDEditorStyles.TextArea = gUIStyle13;
            NDEditorStyles.ToolbarTab = new GUIStyle(EditorStyles.toolbarButton);
            GUIStyle gUIStyle14 = new GUIStyle(NDEditorStyles.BoldLabelWithWordWrap);
            gUIStyle14.padding = (new RectOffset(2, 2, -3, 5));
            NDEditorStyles.ActionPreviewTitle = gUIStyle14;
            GUIStyle gUIStyle15 = new GUIStyle();
            gUIStyle15.normal.background = (Files.LoadTextureFromDll("playMakerLogo", 256, 67));
            gUIStyle15.margin = (new RectOffset(4, 4, 4, 8));
            gUIStyle15.fixedWidth = (256f);
            gUIStyle15.fixedHeight = (67f);
            NDEditorStyles.LogoLarge = gUIStyle15;
            NDEditorStyles.graphTextColor = new Color(1f, 1f, 1f, 0.7f);
            NDEditorStyles.LabelTextColor = EditorStyles.label.normal.textColor;
            GUIStyle gUIStyle16 = new GUIStyle(EditorStyles.toolbarDropDown);
            gUIStyle16.alignment = TextAnchor.MiddleRight;
            NDEditorStyles.RightAlignedToolbarDropdown = gUIStyle16;
            GUIStyle gUIStyle17 = new GUIStyle(EditorStyles.toolbarButton);
            gUIStyle17.alignment = TextAnchor.MiddleLeft;
            NDEditorStyles.ToolbarHeading = gUIStyle17;
            GUIStyle gUIStyle18 = new GUIStyle(EditorStyles.toolbarButton);
            gUIStyle18.padding = (new RectOffset(20, 5, 2, 2));
            gUIStyle18.alignment = TextAnchor.MiddleLeft;
            NDEditorStyles.ErrorCount = gUIStyle18;
            NDEditorStyles.Errors = Files.LoadTextureFromDll("errorCount", 14, 14);
            NDEditorStyles.NoErrors = Files.LoadTextureFromDll("noErrors", 14, 14);
            GUIStyle gUIStyle19 = new GUIStyle();
            gUIStyle19.normal.background = (Files.LoadTextureFromDll("graphBackground", 32, 32));
            gUIStyle19.border = (new RectOffset(16, 16, 20, 10));
            NDEditorStyles.Background = gUIStyle19;
            GUIStyle gUIStyle20 = new GUIStyle();
            gUIStyle20.normal.background = (Files.LoadTextureFromDll("innerGlowBox", 32, 32));
            gUIStyle20.border = (new RectOffset(14, 14, 14, 14));
            NDEditorStyles.InnerGlowBox = gUIStyle20;
            GUIStyle gUIStyle21 = new GUIStyle();
            gUIStyle21.normal.background = (Files.LoadTextureFromDll("outerGlow", 32, 32));
            gUIStyle21.border = (new RectOffset(11, 11, 11, 11));
            gUIStyle21.margin = (new RectOffset(3, 3, 3, 3));
            gUIStyle21.overflow = (new RectOffset(10, 10, 10, 10));
            NDEditorStyles.SelectionBox = gUIStyle21;
            GUIStyle gUIStyle22 = new GUIStyle();
            gUIStyle22.normal.background = (Files.LoadTextureFromDll("selectionRect", 8, 8));
            gUIStyle22.border = (new RectOffset(3, 3, 3, 3));
            NDEditorStyles.SelectionRect = gUIStyle22;
            GUIStyle gUIStyle23 = new GUIStyle();
            gUIStyle23.normal.background = (Files.LoadTextureFromDll("dropShadowBox", 64, 64));
            gUIStyle23.border = (new RectOffset(31, 31, 16, 16));
            gUIStyle23.margin = (new RectOffset(3, 3, 3, 3));
            gUIStyle23.overflow = (new RectOffset(15, 15, 15, 15));
            NDEditorStyles.DropShadowBox = gUIStyle23;
            GUIStyle gUIStyle24 = new GUIStyle();
            gUIStyle24.normal.background = (Files.LoadTextureFromDll("stateBox", 16, 16));
            gUIStyle24.border = (new RectOffset(2, 2, 2, 2));
            gUIStyle24.overflow = (new RectOffset(1, 1, 1, 1));
            NDEditorStyles.StateBox = gUIStyle24;
            GUIStyle gUIStyle25 = new GUIStyle();
            gUIStyle25.normal.background = (Files.LoadTextureFromDll("stateTitleBox", 16, 16));
            gUIStyle25.normal.textColor = (NDEditorStyles.graphTextColor);
            gUIStyle25.border = (new RectOffset(1, 1, 1, 1));
            gUIStyle25.alignment = TextAnchor.MiddleCenter;
            gUIStyle25.fontStyle = FontStyle.Bold;
            gUIStyle25.fontSize = (12);
            gUIStyle25.contentOffset = (new Vector2(0f, -1f));
            gUIStyle25.fixedHeight = (NDEditorStyles.StateRowHeight);
            NDEditorStyles.StateTitleBox = gUIStyle25;
            NDEditorStyles.DefaultStateBoxStyle = new GUIStyle(NDEditorStyles.StateTitleBox);
            GUIStyle gUIStyle26 = new GUIStyle(NDEditorStyles.StateTitleBox);
            gUIStyle26.alignment = TextAnchor.MiddleLeft;
            NDEditorStyles.StateTitleLongBox = gUIStyle26;
            GUIStyle gUIStyle27 = new GUIStyle();
            gUIStyle27.normal.background = (Files.LoadTextureFromDll("transitionBox", 16, 16));
            gUIStyle27.normal.textColor = (Color.white);
            gUIStyle27.border = (new RectOffset(2, 2, 2, 2));
            gUIStyle27.fixedHeight = (NDEditorStyles.StateRowHeight);
            gUIStyle27.alignment = TextAnchor.MiddleCenter;
            NDEditorStyles.TransitionBox = gUIStyle27;
            GUIStyle gUIStyle28 = new GUIStyle(NDEditorStyles.TransitionBox);
            gUIStyle28.normal.background = (Files.LoadTextureFromDll("transitionBoxSelected", 16, 16));
            gUIStyle28.normal.textColor = (NDEditorStyles.graphTextColor);
            NDEditorStyles.TransitionBoxSelected = gUIStyle28;
            GUIStyle gUIStyle29 = new GUIStyle(NDEditorStyles.TransitionBox);
            gUIStyle29.normal.background = (Files.LoadTextureFromDll("globalTransitionBox", 16, 16));
            gUIStyle29.normal.textColor = (NDEditorStyles.graphTextColor);
            gUIStyle29.fontStyle = FontStyle.Bold;
            NDEditorStyles.GlobalTransitionBox = gUIStyle29;
            GUIStyle gUIStyle30 = new GUIStyle(NDEditorStyles.GlobalTransitionBox);
            gUIStyle30.normal.background = (Files.LoadTextureFromDll("startTransitionBox", 16, 16));
            NDEditorStyles.StartTransitionBox = gUIStyle30;
            GUIStyle gUIStyle31 = new GUIStyle();
            gUIStyle31.normal.background = (Files.LoadTextureFromDll("singlePixelFrame", 16, 16));
            gUIStyle31.border = (new RectOffset(8, 8, 8, 8));
            gUIStyle31.padding = (new RectOffset(0, 0, -10, 0));
            NDEditorStyles.SinglePixelFrame = gUIStyle31;
            GUIStyle gUIStyle32 = new GUIStyle();
            gUIStyle32.normal.background = (Files.LoadTextureFromDll("breakpointOff", 5, 16));
            NDEditorStyles.BreakpointOff = gUIStyle32;
            GUIStyle gUIStyle33 = new GUIStyle();
            gUIStyle33.normal.background = (Files.LoadTextureFromDll("breakpointOn", 5, 16));
            NDEditorStyles.BreakpointOn = gUIStyle33;
            NDEditorStyles.TitleIcon = Files.LoadTextureFromDll("wanIcon", 20, 20);
            NDEditorStyles.LineTexture = Files.LoadTextureFromDll("line", 2, 4);
            NDEditorStyles.LeftArrow = Files.LoadTextureFromDll("leftArrow", 23, 14);
            NDEditorStyles.RightArrow = Files.LoadTextureFromDll("rightArrow", 23, 14);
            NDEditorStyles.StartArrow = Files.LoadTextureFromDll("startArrow", 28, 64);
            NDEditorStyles.GlobalArrow = Files.LoadTextureFromDll("globalArrow", 16, 32);
            NDEditorStyles.StateErrorIcon = Files.LoadTextureFromDll("errorCount", 14, 14);
            NDEditorStyles.BroadcastIcon = Files.LoadTextureFromDll("broadcastIcon", 16, 16);
            NDEditorStyles.gameStateIcons = new Texture2D[]
                {
                    default(Texture2D),
                    Files.LoadTextureFromDll("playIcon", 64, 64),
                    Files.LoadTextureFromDll("breakIcon", 64, 64),
                    Files.LoadTextureFromDll("pauseIcon", 64, 64),
                    Files.LoadTextureFromDll("errorIcon", 64, 64)
                };
            GUIStyle gUIStyle34 = new GUIStyle();
            gUIStyle34.normal.background = (Files.LoadTextureFromDll("infoBox", 16, 16));
            gUIStyle34.normal.textColor = (NDEditorStyles.graphTextColor);
            gUIStyle34.border = (new RectOffset(2, 2, 2, 2));
            gUIStyle34.padding = (new RectOffset(5, 5, 3, 3));
            gUIStyle34.margin = (new RectOffset(3, 3, 3, 3));
            gUIStyle34.alignment = (0);
            gUIStyle34.wordWrap = (true);
            gUIStyle34.font = (EditorStyles.standardFont);
            NDEditorStyles.CommentBox = gUIStyle34;
            GUIStyle gUIStyle35 = new GUIStyle();
            gUIStyle35.normal.background = (Files.LoadTextureFromDll("divider", 32, 2));
            gUIStyle35.border = (new RectOffset(1, 1, 2, 0));
            gUIStyle35.fixedHeight = (2f);
            NDEditorStyles.Divider = gUIStyle35;
            GUIStyle gUIStyle36 = new GUIStyle();
            gUIStyle36.normal.background = (Files.LoadTextureFromDll("dividerSequence", 42, 10));
            gUIStyle36.border = (new RectOffset(37, 0, 0, 0));
            gUIStyle36.fixedHeight = (10f);
            NDEditorStyles.DividerSequence = gUIStyle36;
            GUIStyle gUIStyle37 = new GUIStyle(EditorStyles.miniButton);
            gUIStyle37.overflow = (new RectOffset(0, 0, 0, 2));
            gUIStyle37.padding = (new RectOffset(0, 0, 0, 0));
            gUIStyle37.margin = (new RectOffset(0, 0, 3, 2));
            gUIStyle37.stretchWidth = (false);
            gUIStyle37.stretchHeight = (false);
            NDEditorStyles.MiniButton = gUIStyle37;
            GUIStyle gUIStyle38 = new GUIStyle(EditorStyles.miniButton);
            gUIStyle38.overflow = (new RectOffset(0, 0, 0, 2));
            gUIStyle38.padding = (new RectOffset(0, 0, 0, 0));
            gUIStyle38.stretchWidth = (false);
            gUIStyle38.stretchHeight = (false);
            NDEditorStyles.MiniButtonPadded = gUIStyle38;
            GUIStyle gUIStyle39 = new GUIStyle(EditorStyles.foldout);
            gUIStyle39.fixedWidth = (15f);
            gUIStyle39.margin = (new RectOffset(2, 0, -2, 0));
            NDEditorStyles.ActionFoldout = gUIStyle39;
            GUIStyle gUIStyle40 = new GUIStyle(EditorStyles.toggle);
            gUIStyle40.fixedWidth = (15f);
            gUIStyle40.margin = (new RectOffset(0, 0, -2, 0));
            NDEditorStyles.ActionToggle = gUIStyle40;
            GUIStyle gUIStyle41 = new GUIStyle(EditorStyles.boldLabel);
            gUIStyle41.padding = (new RectOffset(2, 0, 2, 0));
            gUIStyle41.margin = (new RectOffset(0, 0, 0, 0));
            gUIStyle41.fixedHeight = (20f);
            NDEditorStyles.ActionTitle = gUIStyle41;
            GUIStyle gUIStyle42 = new GUIStyle(NDEditorStyles.ActionTitle);
            gUIStyle42.normal.textColor = (new Color(0.7f, 0.7f, 0.7f));
            NDEditorStyles.ActionTitleError = gUIStyle42;
            GUIStyle gUIStyle43 = new GUIStyle(EditorStyles.boldLabel);
            gUIStyle43.normal.textColor = (Color.white);
            gUIStyle43.padding = (new RectOffset(2, 0, 2, 0));
            gUIStyle43.margin = (new RectOffset(0, 0, 0, 0));
            gUIStyle43.fixedHeight = (20f);
            NDEditorStyles.ActionTitleSelected = gUIStyle43;
            NDEditorStyles.SelectedBG = Files.LoadTextureFromDll("selectedColor", 2, 2);
            GUIStyle gUIStyle44 = new GUIStyle();
            gUIStyle44.normal.background = (NDEditorStyles.SelectedBG);
            gUIStyle44.normal.textColor = (Color.white);
            gUIStyle44.padding = (new RectOffset(2, 0, 2, 0));
            gUIStyle44.margin = (new RectOffset(0, 0, 0, 0));
            gUIStyle44.fixedHeight = (20f);
            NDEditorStyles.SelectedRow = gUIStyle44;
            GUIStyle gUIStyle45 = new GUIStyle(EditorStyles.foldout);
            gUIStyle45.fontStyle = FontStyle.Bold;
            NDEditorStyles.CategoryFoldout = gUIStyle45;
            GUIStyle gUIStyle46 = new GUIStyle();
            gUIStyle46.normal.background = (Files.LoadTextureFromDll("infoBox", 16, 16));
            gUIStyle46.normal.textColor = (NDEditorStyles.LabelTextColor);
            gUIStyle46.border = (new RectOffset(2, 2, 2, 2));
            gUIStyle46.padding = (new RectOffset(5, 5, 3, 3));
            gUIStyle46.margin = (new RectOffset(5, 5, 3, 3));
            gUIStyle46.alignment = TextAnchor.LowerLeft;
            gUIStyle46.wordWrap = (true);
            NDEditorStyles.InfoBox = gUIStyle46;
            GUIStyle gUIStyle47 = new GUIStyle(NDEditorStyles.InfoBox);
            gUIStyle47.normal.background = (Files.LoadTextureFromDll("hintBox", 16, 16));
            gUIStyle47.normal.textColor = (Color.white);
            NDEditorStyles.HintBox = gUIStyle47;
            GUIStyle gUIStyle48 = new GUIStyle(NDEditorStyles.InfoBox);
            gUIStyle48.normal.background = (Files.LoadTextureFromDll("errorBox", 16, 16));
            gUIStyle48.normal.textColor = (NDEditorStyles.ErrorTextColor);
            NDEditorStyles.ErrorBox = gUIStyle48;
            NDEditorStyles.ActionErrorBox = new GUIStyle(NDEditorStyles.ErrorBox);
            GUIStyle gUIStyle49 = new GUIStyle();
            gUIStyle49.normal.background = (Files.LoadTextureFromDll("transitionBox", 16, 16));
            gUIStyle49.border = (new RectOffset(5, 5, 5, 5));
            gUIStyle49.padding = (new RectOffset(5, 0, 3, 0));
            gUIStyle49.alignment = TextAnchor.MiddleLeft;
            gUIStyle49.fixedHeight = (20f);
            NDEditorStyles.EventBox = gUIStyle49;
            GUIStyle gUIStyle50 = new GUIStyle(NDEditorStyles.EventBox);
            gUIStyle50.normal.background = (NDEditorStyles.SelectedBG);
            gUIStyle50.normal.textColor = (Color.white);
            gUIStyle50.fixedHeight = (22f);
            NDEditorStyles.SelectedEventBox = gUIStyle50;
            GUIStyle gUIStyle51 = new GUIStyle();
            gUIStyle51.normal.background = (Files.LoadTextureFromDll("tableRowBox", 16, 16));
            gUIStyle51.border = (new RectOffset(5, 5, 5, 5));
            gUIStyle51.padding = (new RectOffset(5, 0, 3, 0));
            gUIStyle51.alignment = TextAnchor.MiddleLeft;
            gUIStyle51.fixedHeight = (22f);
            NDEditorStyles.TableRowBox = gUIStyle51;
            GUIStyle gUIStyle52 = new GUIStyle();
            gUIStyle52.border = (new RectOffset(5, 5, 5, 5));
            gUIStyle52.padding = (new RectOffset(5, 0, 3, 0));
            gUIStyle52.alignment = TextAnchor.MiddleLeft;
            gUIStyle52.fixedHeight = (22f);
            NDEditorStyles.TableRowBoxNoDivider = gUIStyle52;
            GUIStyle gUIStyle53 = new GUIStyle("Label");
            gUIStyle53.alignment = TextAnchor.MiddleLeft;
            NDEditorStyles.TableRowHeader = gUIStyle53;
            GUIStyle gUIStyle54 = new GUIStyle();
            gUIStyle54.padding = (new RectOffset(5, 5, 0, 0));
            gUIStyle54.alignment = TextAnchor.LowerRight;
            NDEditorStyles.VersionInfo = gUIStyle54;
            GUIStyle gUIStyle55 = new GUIStyle();
            gUIStyle55.normal.background = (Files.LoadTextureFromDll("logInfoIcon", 20, 20));
            gUIStyle55.normal.textColor = (EditorStyles.label.normal.textColor);
            gUIStyle55.border = (new RectOffset(20, 0, 0, 0));
            gUIStyle55.padding = (new RectOffset(24, 0, 0, 0));
            gUIStyle55.margin = (new RectOffset(3, 3, 0, 0));
            gUIStyle55.alignment = TextAnchor.MiddleLeft;
            gUIStyle55.fixedHeight = (20f);
            NDEditorStyles.LogInfo = gUIStyle55;
            GUIStyle gUIStyle56 = new GUIStyle(NDEditorStyles.LogInfo);
            GUIStyle gUIStyle57 = new GUIStyle(NDEditorStyles.LogInfo);
            gUIStyle57.normal.background = (null);
            gUIStyle57.fontStyle = FontStyle.Bold;
            GUIStyle gUIStyle58 = gUIStyle57;
            GUIStyle gUIStyle59 = new GUIStyle(gUIStyle58);
            GUIStyle gUIStyle60 = new GUIStyle(NDEditorStyles.LogInfo);
            gUIStyle60.normal.background = (Files.LoadTextureFromDll("logWarningIcon", 20, 20));
            GUIStyle gUIStyle61 = gUIStyle60;
            GUIStyle gUIStyle62 = new GUIStyle(NDEditorStyles.LogInfo);
            gUIStyle62.normal.background = (Files.LoadTextureFromDll("logErrorIcon", 20, 20));
            GUIStyle gUIStyle63 = gUIStyle62;
            GUIStyle gUIStyle64 = new GUIStyle(NDEditorStyles.LogInfo);
            gUIStyle64.normal.background = (Files.LoadTextureFromDll("logTransitionIcon", 20, 20));
            GUIStyle gUIStyle65 = gUIStyle64;
            NDEditorStyles.logTypeStyles = new GUIStyle[]
                {
                    NDEditorStyles.LogInfo,
                    gUIStyle61,
                    gUIStyle63,
                    NDEditorStyles.LogInfo,
                    gUIStyle65,
                    NDEditorStyles.LogInfo,
                    gUIStyle65,
                    NDEditorStyles.LogInfo,
                    gUIStyle56,
                    gUIStyle58,
                    gUIStyle59
                };
            GUIStyle gUIStyle66 = new GUIStyle();
            gUIStyle66.normal.textColor = (EditorStyles.label.normal.textColor);
            gUIStyle66.padding = (new RectOffset(16, 0, 0, 0));
            gUIStyle66.margin = (new RectOffset(3, 4, 0, 0));
            gUIStyle66.alignment = (0);
            gUIStyle66.fixedHeight = (16f);
            NDEditorStyles.ActionItem = gUIStyle66;
            GUIStyle gUIStyle67 = new GUIStyle(NDEditorStyles.ActionItem);
            gUIStyle67.normal.background = (NDEditorStyles.SelectedBG);
            gUIStyle67.normal.textColor = (Color.white);
            NDEditorStyles.ActionItemSelected = gUIStyle67;
            GUIStyle gUIStyle68 = new GUIStyle(EditorStyles.label);
            gUIStyle68.margin = (new RectOffset(3, 4, 0, 0));
            gUIStyle68.alignment = (0);
            gUIStyle68.fixedHeight = (16f);
            NDEditorStyles.ActionLabel = gUIStyle68;
            GUIStyle gUIStyle69 = new GUIStyle(NDEditorStyles.ActionLabel);
            gUIStyle69.normal.textColor = (Color.white);
            NDEditorStyles.ActionLabelSelected = gUIStyle69;
            GUIStyle gUIStyle70 = new GUIStyle();
            gUIStyle70.normal.textColor = (EditorStyles.label.normal.textColor);
            gUIStyle70.padding = (new RectOffset(1, 0, 3, 2));
            gUIStyle70.fixedHeight = (18f);
            NDEditorStyles.TableRow = gUIStyle70;
            GUIStyle gUIStyle71 = new GUIStyle(NDEditorStyles.TableRow);
            gUIStyle71.normal.background = (NDEditorStyles.SelectedBG);
            gUIStyle71.normal.textColor = (Color.white);
            NDEditorStyles.TableRowSelected = gUIStyle71;
            NDEditorStyles.TableRowText = new GUIStyle("Label");
            GUIStyle gUIStyle72 = new GUIStyle(NDEditorStyles.TableRowText);
            gUIStyle72.normal.textColor = (Color.white);
            NDEditorStyles.TableRowTextSelected = gUIStyle72;
            GUIStyle gUIStyle73 = new GUIStyle("Toggle");
            gUIStyle73.padding = (new RectOffset(0, 0, 0, 0));
            gUIStyle73.margin = (new RectOffset(4, 0, 1, 0));
            NDEditorStyles.TableRowCheckBox = gUIStyle73;
            GUIStyle gUIStyle74 = new GUIStyle(EditorStyles.foldout);
            gUIStyle74.fontStyle = FontStyle.Bold;
            NDEditorStyles.BoldFoldout = gUIStyle74;
            GUIStyle gUIStyle75 = new GUIStyle();
            gUIStyle75.normal.background = (Files.LoadTextureFromDll("logEntryBox", 16, 16));
            gUIStyle75.normal.textColor = (Color.white);
            NDEditorStyles.LogBackground = gUIStyle75;
            GUIStyle gUIStyle76 = new GUIStyle();
            gUIStyle76.normal.textColor = (Color.white);
            gUIStyle76.padding = (new RectOffset(1, 0, 3, 2));
            gUIStyle76.fixedHeight = (18f);
            NDEditorStyles.LogLine = gUIStyle76;
            GUIStyle gUIStyle77 = new GUIStyle(NDEditorStyles.LogLine);
            gUIStyle77.padding = (new RectOffset(27, 0, 3, 2));
            NDEditorStyles.LogLine2 = gUIStyle77;
            GUIStyle gUIStyle78 = new GUIStyle(NDEditorStyles.LogLine);
            gUIStyle78.normal.background = (NDEditorStyles.SelectedBG);
            gUIStyle78.normal.textColor = (Color.white);
            NDEditorStyles.LogLineSelected = gUIStyle78;
            GUIStyle gUIStyle79 = new GUIStyle();
            gUIStyle79.normal.background = (Files.LoadTextureFromDll("yellow", 2, 6));
            gUIStyle79.normal.textColor = (Color.white);
            gUIStyle79.fixedHeight = (6f);
            NDEditorStyles.LogLineTimeline = gUIStyle79;
            GUIStyle gUIStyle80 = new GUIStyle();
            gUIStyle80.normal.background = (Files.LoadTextureFromDll("pasteDivider", 2, 2));
            gUIStyle80.normal.textColor = (Color.white);
            gUIStyle80.fixedHeight = (2f);
            NDEditorStyles.InsertLine = gUIStyle80;
            NDEditorStyles.DefaultWatermark = Files.LoadTextureFromDll("playMakerWatermark", 256, 256);
            GUIStyle gUIStyle81 = new GUIStyle();
            gUIStyle81.alignment = TextAnchor.LowerRight;
            NDEditorStyles.Watermark = gUIStyle81;
            GUIStyle gUIStyle82 = new GUIStyle(EditorStyles.label);
            gUIStyle82.normal.textColor = (new Color(1f, 1f, 1f, 0.1f));
            gUIStyle82.fontSize = (32);
            gUIStyle82.fontStyle = FontStyle.Bold;
            NDEditorStyles.LargeWatermarkText = gUIStyle82;
            GUIStyle gUIStyle83 = new GUIStyle();
            gUIStyle83.normal.textColor = (new Color(1f, 1f, 1f, 0.15f));
            gUIStyle83.padding = (new RectOffset(5, 0, 0, 0));
            gUIStyle83.font = (EditorStyles.standardFont);
            gUIStyle83.fontSize = (14);
            gUIStyle83.fontStyle = FontStyle.Normal;
            gUIStyle83.wordWrap = (true);
            NDEditorStyles.SmallWatermarkText = gUIStyle83;
            GUIStyle gUIStyle84 = new GUIStyle(EditorStyles.label);
            gUIStyle84.fontSize = (32);
            gUIStyle84.fontStyle = FontStyle.Bold;
            NDEditorStyles.LargeTitleText = gUIStyle84;
            GUIStyle gUIStyle85 = new GUIStyle();
            gUIStyle85.normal.textColor = (Color.white);
            gUIStyle85.fontSize = (32);
            gUIStyle85.fontStyle = FontStyle.Bold;
            NDEditorStyles.LargeText = gUIStyle85;
            GUIStyle gUIStyle86 = new GUIStyle();
            gUIStyle86.normal.background = (Files.LoadTextureFromDll("wanLarge", 42, 42));
            gUIStyle86.normal.textColor = (Color.white);
            gUIStyle86.border = (new RectOffset(42, 0, 0, 0));
            gUIStyle86.padding = (new RectOffset(42, 0, 0, 0));
            gUIStyle86.margin = (new RectOffset(0, 0, 0, 0));
            gUIStyle86.contentOffset = (new Vector2(0f, 0f));
            gUIStyle86.alignment = TextAnchor.MiddleLeft;
            gUIStyle86.fixedHeight = (42f);
            gUIStyle86.fontSize = (32);
            gUIStyle86.fontStyle = FontStyle.Bold;
            NDEditorStyles.LargeTitleWithLogo = gUIStyle86;
            GUIStyle gUIStyle87 = new GUIStyle();
            gUIStyle87.normal.background = (Files.LoadTextureFromDll("playMakerHeader", 253, 60));
            gUIStyle87.normal.textColor = (Color.white);
            gUIStyle87.border = (new RectOffset(253, 0, 0, 0));
            NDEditorStyles.PlaymakerHeader = gUIStyle87;
            GUIStyle gUIStyle88 = new GUIStyle();
            gUIStyle88.normal.textColor = (EditorStyles.label.normal.textColor);
            gUIStyle88.border = (new RectOffset(64, 0, 0, 0));
            gUIStyle88.padding = (new RectOffset(66, 0, 0, 0));
            gUIStyle88.margin = (new RectOffset(20, 20, 20, 0));
            gUIStyle88.alignment = (0);
            gUIStyle88.fixedHeight = (64f);
            NDEditorStyles.WelcomeLink = gUIStyle88;
            NDEditorStyles.DocsIcon = Files.LoadTextureFromDll("linkDocs", 48, 48);
            NDEditorStyles.BasicsIcon = Files.LoadTextureFromDll("linkBasics", 64, 64);
            NDEditorStyles.VideoIcon = Files.LoadTextureFromDll("linkVideos", 48, 48);
            NDEditorStyles.ForumIcon = Files.LoadTextureFromDll("linkForums", 48, 48);
            NDEditorStyles.SamplesIcon = Files.LoadTextureFromDll("linkSamples", 48, 48);
            NDEditorStyles.PhotonIcon = Files.LoadTextureFromDll("photonIcon", 48, 48);
            NDEditorStyles.BlackBerryAddonIcon = Files.LoadTextureFromDll("bb10Icon", 48, 48);
            NDEditorStyles.WP8AddonIcon = Files.LoadTextureFromDll("wp8Icon", 48, 48);
            NDEditorStyles.MetroAddonIcon = Files.LoadTextureFromDll("metroIcon", 48, 48);
            NDEditorStyles.AddonsIcon = Files.LoadTextureFromDll("linkAddons", 48, 48);
            NDEditorStyles.BackButton = Files.LoadTextureFromDll("backButton", 123, 24);
            GUIStyle gUIStyle89 = new GUIStyle();
            gUIStyle89.padding = (new RectOffset(2, 0, 2, 0));
            NDEditorStyles.InlineErrorIcon = gUIStyle89;
        }
        private static void InitProSkin()
        {
            NDEditorStyles.BroadcastIcon = Files.LoadTextureFromDll("broadcastIcon", 16, 16);
            NDEditorStyles.GuiContentErrorColor = new Color(1f, 0.1f, 0.1f);
            NDEditorStyles.GuiBackgroundErrorColor = new Color(1f, 0.4f, 0.4f);
            GUIStyle gUIStyle = new GUIStyle(NDEditorStyles.InfoBox);
            gUIStyle.normal.background = (Files.LoadTextureFromDll("hintBox", 16, 16));
            gUIStyle.normal.textColor = (new Color(0.6f, 0.7f, 0.8f));
            NDEditorStyles.HintBox = gUIStyle;
            GUIStyle gUIStyle2 = new GUIStyle(NDEditorStyles.HintBox);
            gUIStyle2.normal.background = (null);
            NDEditorStyles.HintBoxTextOnly = gUIStyle2;
        }
        private static void InitIndieSkin()
        {
            NDEditorStyles.ErrorBox.normal.background = (NDEditorStyles.InfoBox.normal.background);
            NDEditorStyles.ErrorBox.normal.textColor = (NDEditorStyles.ErrorTextColorIndie);
            NDEditorStyles.ActionErrorBox.normal.textColor = (NDEditorStyles.ErrorTextColorIndie);
            NDEditorStyles.BroadcastIcon = Files.LoadTextureFromDll("broadcastIcon_indie", 16, 16);
            NDEditorStyles.SelectedBG = Files.LoadTextureFromDll("selectedColor_indie", 2, 2);
            NDEditorStyles.SelectedRow.normal.background = (NDEditorStyles.SelectedBG);
            NDEditorStyles.ActionItemSelected.normal.background = (NDEditorStyles.SelectedBG);
            NDEditorStyles.SelectedEventBox.normal.background = (NDEditorStyles.SelectedBG);
            NDEditorStyles.TableRowSelected.normal.background = (NDEditorStyles.SelectedBG);
            NDEditorStyles.GuiContentErrorColor = new Color(1f, 0f, 0f);
            NDEditorStyles.GuiBackgroundErrorColor = new Color(1f, 0.3f, 0.3f);
            GUIStyle gUIStyle = new GUIStyle(NDEditorStyles.InfoBox);
            gUIStyle.normal.background = (Files.LoadTextureFromDll("hintBox", 16, 16));
            gUIStyle.normal.textColor = (new Color(0.9f, 0.95f, 1f));
            NDEditorStyles.HintBox = gUIStyle;
            GUIStyle gUIStyle2 = new GUIStyle(NDEditorStyles.HintBox);
            gUIStyle2.normal.background = (null);
            NDEditorStyles.HintBoxTextOnly = gUIStyle2;
        }
        private static void InitColorScheme(NDEditorStyles.ColorScheme colorScheme)
        {
            if (colorScheme == NDEditorStyles.ColorScheme.Default)
            {
                colorScheme = (NDEditorStyles.usingProSkin ? NDEditorStyles.ColorScheme.DarkBackground : NDEditorStyles.ColorScheme.LightBackground);
            }
            switch (colorScheme)
            {
                case NDEditorStyles.ColorScheme.DarkBackground:
                    NDEditorStyles.LinkColors[0] = new Color(0.1f, 0.1f, 0.1f);
                    NDEditorStyles.LargeWatermarkText.normal.textColor = (new Color(1f, 1f, 1f, 0.15f));
                    NDEditorStyles.SmallWatermarkText.normal.textColor = (new Color(1f, 1f, 1f, 0.2f));
                    NDEditorStyles.MinimapViewRectColor = new Color(1f, 1f, 1f, 0.3f);
                    NDEditorStyles.MinimapFrameColor = new Color(1f, 1f, 1f, 0.05f);
                    NDEditorStyles.WatermarkTint = new Color(1f, 1f, 1f, 0.05f);
                    NDEditorStyles.WatermarkTintSolid = new Color(0.8f, 0.8f, 0.8f);
                    NDEditorStyles.HighlightColors = new Color[]
                        {
                            new Color(0f, 0f, 0f),
                            new Color(0.24f, 0.38f, 0.57f),
                            new Color(0.06f, 0.8f, 0.06f),
                            new Color(1f, 0f, 0f),
                            new Color(1f, 0f, 0f),
                            new Color(0.8f, 0.8f, 0f)
                        };
                    return;
                case NDEditorStyles.ColorScheme.LightBackground:
                    NDEditorStyles.LinkColors[0] = new Color(0.25f, 0.25f, 0.25f);
                    NDEditorStyles.Background.normal.background = (Files.LoadTextureFromDll("graphBackground_indie", 32, 32));
                    NDEditorStyles.CommentBox.normal.background = (Files.LoadTextureFromDll("infoBox_indie", 16, 16));
                    NDEditorStyles.GlobalTransitionBox.normal.background = (Files.LoadTextureFromDll("globalTransitionBox_indie", 16, 16));
                    NDEditorStyles.StartTransitionBox.normal.background = (Files.LoadTextureFromDll("startTransitionBox_indie", 16, 16));
                    NDEditorStyles.LargeWatermarkText.normal.textColor = (new Color(0f, 0f, 0f, 0.2f));
                    NDEditorStyles.SmallWatermarkText.normal.textColor = (new Color(0f, 0f, 0f, 0.3f));
                    NDEditorStyles.MinimapViewRectColor = new Color(1f, 1f, 1f, 0.5f);
                    NDEditorStyles.MinimapFrameColor = new Color(0f, 0f, 0f, 0.1f);
                    NDEditorStyles.WatermarkTint = new Color(0f, 0f, 0f, 0.075f);
                    NDEditorStyles.WatermarkTintSolid = new Color(0.2f, 0.2f, 0.2f);
                    NDEditorStyles.HighlightColors = new Color[]
                        {
                            new Color(0f, 0f, 0f),
                            new Color(0.24f, 0.5f, 0.875f),
                            new Color(0.06f, 0.8f, 0.06f),
                            new Color(1f, 0f, 0f),
                            new Color(1f, 0f, 0f),
                            new Color(0.8f, 0.8f, 0f)
                        };
                    return;
                default:
                    throw new ArgumentOutOfRangeException("colorScheme");
            }
        }
        public static Texture2D[] GetGameStateIcons()
        {
            return NDEditorStyles.gameStateIcons;
        }
        public static GUIStyle[] GetLogTypeStyles()
        {
            return NDEditorStyles.logTypeStyles;
        }
        public static void OnDestroy()
        {
        }
        public static void InitScale(float scale)
        {
            NDEditorStyles.scaleInitialized = false;
            NDEditorStyles.initScale = scale;
        }
        public static void SetScale(float scale)
        {
            int fontSize = Mathf.CeilToInt(Mathf.Clamp(scale * 12f, 4f, 12f));
            NDEditorStyles.StateRowHeight = 16f * scale;
            NDEditorStyles.StateTitleBox.fontSize = fontSize;
            NDEditorStyles.StateTitleBox.fixedHeight = NDEditorStyles.StateRowHeight;
            NDEditorStyles.TransitionBox.fontSize = fontSize;
            NDEditorStyles.TransitionBox.fixedHeight = NDEditorStyles.StateRowHeight;
            NDEditorStyles.TransitionBoxSelected.fontSize = fontSize;
            NDEditorStyles.TransitionBoxSelected.fixedHeight = NDEditorStyles.StateRowHeight;
            NDEditorStyles.GlobalTransitionBox.fontSize = fontSize;
            NDEditorStyles.GlobalTransitionBox.fixedHeight = NDEditorStyles.StateRowHeight;
            NDEditorStyles.StartTransitionBox.fontSize = fontSize;
            NDEditorStyles.StartTransitionBox.fixedHeight = NDEditorStyles.StateRowHeight;
            NDEditorStyles.CommentBox.fontSize = fontSize;
            NDEditorStyles.CommentBox.padding = new RectOffset((int)(5f * scale), (int)(5f * scale), (int)(3f * scale), (int)(3f * scale));
            NDEditorStyles.scaleInitialized = true;
        }
    }
}
