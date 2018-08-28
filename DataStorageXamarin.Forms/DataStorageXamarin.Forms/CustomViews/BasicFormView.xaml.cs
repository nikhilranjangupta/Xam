using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DataStorageXamarin.Forms.CustomViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BasicFormView : ContentView
    {
        public static readonly BindableProperty LabelText1Property =
 BindableProperty.Create("LabelText1", typeof(string), typeof(BasicFormView), "");

        public static readonly BindableProperty EntryPlaceHolder1Property =
 BindableProperty.Create("EntryPlaceHolder1", typeof(string), typeof(BasicFormView), "");

        public static readonly BindableProperty LabelText2Property =
 BindableProperty.Create("LabelText2", typeof(string), typeof(BasicFormView), "");

        public static readonly BindableProperty EntryPlaceHolder2Property =
 BindableProperty.Create("EntryPlaceHolder2", typeof(string), typeof(BasicFormView), "");

        public static readonly BindableProperty HeadingOfFormProperty =
 BindableProperty.Create("HeadingOfForm", typeof(string), typeof(BasicFormView), "");

        public static BindableProperty EntryText1Property =
BindableProperty.Create("EntryText1", typeof(string), typeof(BasicFormView), "",BindingMode.TwoWay);

        public static BindableProperty EntryText2Property =
BindableProperty.Create("EntryText2", typeof(string), typeof(BasicFormView), "",BindingMode.TwoWay);

        public static readonly BindableProperty LeftButtonTextProperty =
BindableProperty.Create("LeftButtonText", typeof(string), typeof(BasicFormView), "");

        public static readonly BindableProperty RightButtonTextProperty =
BindableProperty.Create("RightButtonText", typeof(string), typeof(BasicFormView), "");

        public static readonly BindableProperty RightButtonCommandProperty =
BindableProperty.Create("RightButtonCommand", typeof(ICommand), typeof(BasicFormView), null);

        public static readonly BindableProperty LeftButtonCommandProperty =
BindableProperty.Create("LeftButtonCommand", typeof(ICommand), typeof(BasicFormView), null);

        public event Action LeftButtonClicked;
        public event Action<string, string> RightButtonClicked;

        public ICommand LeftButtonCommand
        {
            set { SetValue(LeftButtonCommandProperty, value); }
            get { return (ICommand)GetValue(LeftButtonCommandProperty); }
        }

        public ICommand RightButtonCommand
        {
            set { SetValue(RightButtonCommandProperty, value); }
            get { return (ICommand)GetValue(RightButtonCommandProperty); }
        }

        public string LeftButtonText
        {
            set { SetValue(LeftButtonTextProperty, value); }
            get { return (string)GetValue(LeftButtonTextProperty); }
        }

        public string RightButtonText
        {
            set { SetValue(RightButtonTextProperty, value); }
            get { return (string)GetValue(RightButtonTextProperty); }
        }

        public string EntryText1
        {
            set
            {
                SetValue(EntryText1Property, value);
                ((Command)RightButtonCommand)?.ChangeCanExecute();
            }
            get { return (string)GetValue(EntryText1Property); }
        }

        public string EntryText2
        {
            set
            {
                SetValue(EntryText2Property, value);
                ((Command)RightButtonCommand)?.ChangeCanExecute();
            }
            get { return (string)GetValue(EntryText2Property); }
        }


        public string HeadingOfForm
        {
            set { SetValue(HeadingOfFormProperty, value); }
            get { return (string)GetValue(HeadingOfFormProperty); }
        }

        public string LabelText1
        {
            set { SetValue(LabelText1Property, value); }
            get { return (string)GetValue(LabelText1Property); }
        }

        public string EntryPlaceHolder1
        {
            set { SetValue(EntryPlaceHolder1Property, value); }
            get { return (string)GetValue(EntryPlaceHolder1Property); }
        }

        public string LabelText2
        {
            set { SetValue(LabelText2Property, value); }
            get { return (string)GetValue(LabelText2Property); }
        }

        public string EntryPlaceHolder2
        {
            set { SetValue(EntryPlaceHolder2Property, value); }
            get { return (string)GetValue(EntryPlaceHolder2Property); }
        }

        public BasicFormView()
        {
            InitializeComponent();
            BindingContext = this;

            RightButtonCommand = new Command(
             execute: () =>
             {
                 RightButtonClicked(EntryText1, EntryText2);
             },
             canExecute: () => { return ((EntryText1.Length > 0 && EntryText2.Length > 0) ? true : false); });

            LeftButtonCommand = new Command(execute: () => { LeftButtonClicked(); });
        }
    }
}